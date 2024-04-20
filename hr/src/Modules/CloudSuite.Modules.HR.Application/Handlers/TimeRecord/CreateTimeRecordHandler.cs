using CloudSuite.Commons.ValueObjects;
using CloudSuite.Modules.HR.Application.Handlers.TimeRecord.Responses;
using CloudSuite.Modules.HR.Application.Handlers.TimeRecord;
using CloudSuite.Modules.HR.Application.Validations.Employee;
using CloudSuite.Modules.HR.Domain.Contracts;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using System.Text.Json;
using NetDevPack.Messaging;
using CloudSuite.Modules.HR.Application.Validations.TimeRecord;
using System.Threading.Tasks;

namespace CloudSuite.Modules.HR.Application.Handlers.TimeRecord
{
    public class CreateTimeRecordHandler : IRequestHandler<CreateTimeRecordCommand, CreateTimeRecordResponse>
    {
        private readonly ITimeRecordRepository _TimeRecordRepository;
        private readonly ILogger<CreateTimeRecordHandler> _logger;

        public CreateTimeRecordHandler(ITimeRecordRepository timeRecordRepository, ILogger<CreateTimeRecordHandler> logger)
        {
            _TimeRecordRepository = timeRecordRepository;
            _logger = logger;

        }

        public async Task<CreateTimeRecordResponse> Handle(CreateTimeRecordCommand command, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"CreateTimeRecordCommand: {JsonSerializer.Serialize(command)}");
            var validationResult = new CreateTimeRecordCommandValidation().Validate(command);
            if (validationResult.IsValid)
            {
                try
                {
                    
                    var timeRecordEntryTime = await _TimeRecordRepository.GetByEntryTime(command.EntryTime);
                    var timeRecordExitTime = await _TimeRecordRepository.GetByExitTime(command.ExitTime);
                    var timeRecordLunchEntryTime = await _TimeRecordRepository.GetByLunchEntryTime(command.LunchEntryTime);
                    var timeRecordLunchReturnTime = await _TimeRecordRepository.GetByLunchReturnTime(command.LunchReturnTime);
                    var timeRecordLunchExitTimee = await _TimeRecordRepository.GetByLunchExitTime(command.LunchExitTime);


                    if (timeRecordEntryTime != null && timeRecordExitTime != null && timeRecordLunchEntryTime != null && timeRecordLunchReturnTime != null && timeRecordLunchExitTimee != null)
                    {
                        return await Task.FromResult(new CreateTimeRecordResponse(command.id, "User already registered."));
                    }
                    await _TimeRecordRepository.Add(command.GetEntity());
                    return await Task.FromResult(new CreateTimeRecordResponse(command.id, validationResult));
                }
                catch (Exception ex)
                {
                    _logger.LogCritical(ex.Message);
                    return await Task.FromResult(new CreateTimeRecordResponse(command.id, "Failed to process the request."));
                }

            }
            return await Task.FromResult(new CreateTimeRecordResponse(command.id, validationResult));
           
        }
    }
}
