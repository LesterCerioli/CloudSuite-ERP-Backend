using MediatR;
using System.Text.Json;
using Microsoft.Extensions.Logging;
using CloudSuite.Application.Validations;
using CloudSuite.Modules.Domain.Contracts;
using CloudSuite.Application.Handlers.Companies.Responses;
using CloudSuite.Modules.Commons.ValueObjects;

namespace CloudSuite.Application.Handlers.Companies
{
    public class CreateCompanyHandler : IRequestHandler<CreateCompanyCommand, CreateCompanyResponse>
    {
        private ICompanyRepository _repositorioCompany;
        private readonly ILogger<CreateCompanyHandler> _logger;

        public CreateCompanyHandler(ICompanyRepository repositorioCompany, ILogger<CreateCompanyHandler> logger)
        {
            _repositorioCompany = repositorioCompany;
            _logger = logger;
        }

        public async Task<CreateCompanyResponse> Handle(CreateCompanyCommand command, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"CreateCompanyCommand: {JsonSerializer.Serialize(command)}");
            var validationResult = new CreateCompanyCommandValidation().Validate(command);

            if (validationResult.IsValid)
            {
                try
                {
                    var company = await _repositorioCompany.GetByCnpj(new Cnpj(command.Cnpj));
                    if (company != null)
                    {
                        return await Task.FromResult(new CreateCompanyResponse(command.Id, "Company already registered."));
                    }

                    await _repositorioCompany.Add(command.GetEntity());
                    return await Task.FromResult(new CreateCompanyResponse(command.Id, validationResult));
                }
                catch (Exception ex)
                {
                    _logger.LogCritical(ex.Message);
                    return await Task.FromResult(new CreateCompanyResponse(command.Id, "It wasn`t possible to process the solicitation."));
                }
            }

            return await Task.FromResult(new CreateCompanyResponse(command.Id, validationResult));

        }
    }
}
