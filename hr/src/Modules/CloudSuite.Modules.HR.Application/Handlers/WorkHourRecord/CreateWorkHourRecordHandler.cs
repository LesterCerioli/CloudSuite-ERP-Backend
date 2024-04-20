using CloudSuite.Commons.ValueObjects;
using CloudSuite.Modules.HR.Application.Handlers.Employees.Responses;
using CloudSuite.Modules.HR.Application.Handlers.Employees;
using CloudSuite.Modules.HR.Application.Validations.Employee;
using CloudSuite.Modules.HR.Domain.Contracts;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using CloudSuite.Modules.HR.Application.Handlers.WorkHourRecord.Responses;
using NetDevPack.Messaging;
using System.Text.Json;
using CloudSuite.Modules.HR.Application.Validations.WorkHourRecord;
using CloudSuite.Modules.HR.Application.Handlers.TimeRecord.Responses;
using FluentValidation;

namespace CloudSuite.Modules.HR.Application.Handlers.WorkHourRecord
{
    public class CreateWorkHourRecordHandler : IRequestHandler<CreateWorkHourRecordCommand, CreateWorkHourRecordResponse>
    {

        private readonly IWorkHourRecordRepository _workHourRecordRepository;
        private readonly ILogger<CreateWorkHourRecordHandler> _logger;


        public CreateWorkHourRecordHandler(IWorkHourRecordRepository workHourRecordRepository, ILogger<CreateWorkHourRecordHandler> logger)
        {
            _workHourRecordRepository = workHourRecordRepository;
            _logger = logger;

        }

        public async Task<CreateWorkHourRecordResponse> Handle(CreateWorkHourRecordCommand command, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"CreateWorkHourRecordCommand: {JsonSerializer.Serialize(command)}");
            var validationResult = new CreateWorkHourRecordCommandValidation().Validate(command);

            if (validationResult.IsValid)
            {
                try
                {
                           
                    var WorkHourRecordWorkedHours = await _workHourRecordRepository.GetByWorkedHours(command.WorkedHours);
                    var WorkHourRecordYear = await _workHourRecordRepository.GetByYear(command.Year);
                    var WorkHourRecordMonth = await _workHourRecordRepository.GetByMonth(command.Month);

                    if (WorkHourRecordWorkedHours != null && WorkHourRecordYear != null && WorkHourRecordMonth != null)
                    {
                        return await Task.FromResult(new CreateWorkHourRecordResponse(command.id, "User already registered."));
                    }
                    await _workHourRecordRepository.Add(command.GetEntity());
                    return await Task.FromResult(new CreateWorkHourRecordResponse(command.id, validationResult));
                }
                catch (Exception ex)
                {
                    _logger.LogCritical(ex.Message);
                    return await Task.FromResult(new CreateWorkHourRecordResponse(command.id, "Failed to process the request."));
                }

            }

            return await Task.FromResult(new CreateWorkHourRecordResponse(command.id, validationResult));
            
        }
    }
}
