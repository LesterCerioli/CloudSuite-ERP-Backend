using CloudSuite.Commons.ValueObjects;
using CloudSuite.Modules.HR.Application.Handlers.Employees.Responses;
using CloudSuite.Modules.HR.Application.Validations.Employee;
using CloudSuite.Modules.HR.Domain.Contracts;
using MediatR;
using Microsoft.Extensions.Logging;
using NetDevPack.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace CloudSuite.Modules.HR.Application.Handlers.Employees
{
    public class CreateEmployeeHandler : IRequestHandler<CreateEmployeeCommand, CreateEmployeeResponse>
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly ILogger<CreateEmployeeHandler> _logger;

        public CreateEmployeeHandler(IEmployeeRepository employeeRepository, ILogger<CreateEmployeeHandler> logger) 
        {
            _employeeRepository = employeeRepository;
            _logger = logger;

        }
           
        public async Task<CreateEmployeeResponse> Handle(CreateEmployeeCommand command, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"CreateEmployeeCommand: {JsonSerializer.Serialize(command)}");
            var validationResult = new CreateEmployeeCommandValidation().Validate(command);

            if (validationResult.IsValid)
            {
                try
                {

                    var employeeCpf = await _employeeRepository.GetByCpf(new Cpf(command.Cpf));

                    if (employeeCpf != null)
                    {
                        return await Task.FromResult(new CreateEmployeeResponse(command.id, "User already registered."));
                    }
                    await _employeeRepository.Add(command.GetEntity());
                    return await Task.FromResult(new CreateEmployeeResponse(command.id, validationResult));
                }
                catch (Exception ex)
                {
                    _logger.LogCritical(ex.Message);
                    return await Task.FromResult(new CreateEmployeeResponse(command.id, "Failed to process the request."));
                }

            }
            return await Task.FromResult(new CreateEmployeeResponse(command.id, validationResult));
        }
    }
}
