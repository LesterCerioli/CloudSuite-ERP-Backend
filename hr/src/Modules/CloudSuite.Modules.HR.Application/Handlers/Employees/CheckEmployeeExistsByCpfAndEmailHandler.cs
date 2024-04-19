using CloudSuite.Commons.ValueObjects;
using CloudSuite.Modules.HR.Application.Core;
using CloudSuite.Modules.HR.Application.Handlers.Employees.Responses;
using CloudSuite.Modules.HR.Application.Validations.Employee;
using CloudSuite.Modules.HR.Domain.Contracts;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Web.Http.Results;

namespace CloudSuite.Modules.HR.Application.Handlers.Employees
{
	public class CheckEmployeeExistsByCpfAndEmailHandler : Response
	{
        private readonly IEmployeeRepository _employeeRepository;
        private readonly ILogger<CreateEmployeeHandler> _logger;

        public CheckEmployeeExistsByCpfAndEmailHandler(IEmployeeRepository employeeRepository, ILogger<CreateEmployeeHandler> logger)
        {
            _employeeRepository = employeeRepository;
            _logger = logger;

        }
                 
        public async Task<CheckEmployeeExistsByCpfAndEmailResponse> Handle(CreateEmployeeCommand command, CancellationToken cancellationToken)
        {                 
            _logger.LogInformation($"CreateEmployeeCommand: {JsonSerializer.Serialize(command)}");
            var validationResult = new CreateEmployeeCommandValidation().Validate(command);

            if (validationResult.IsValid)
             
            {
                try
                {
                    var employeeCpf = await _employeeRepository.GetByCpf(new Cpf(command.Cpf));

                    if (command != null)

                        return await Task.FromResult(new CheckEmployeeExistsByCpfAndEmailResponse(command.id, true, validationResult));
                }
                catch (Exception ex)
                {
                    _logger.LogCritical(ex.Message);
                    return await Task.FromResult(new CheckEmployeeExistsByCpfAndEmailResponse(command.id, "Unable to process request."));
                }
            }

            return await Task.FromResult(new CheckEmployeeExistsByCpfAndEmailResponse(command.id, false, validationResult));

        }

    }
}
