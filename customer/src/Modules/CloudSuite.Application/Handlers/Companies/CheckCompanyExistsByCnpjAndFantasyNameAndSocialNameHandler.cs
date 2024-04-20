using CloudSuite.Application.Handlers.Companies.Requests;
using CloudSuite.Application.Handlers.Companies.Responses;
using CloudSuite.Modules.Commons.ValueObjects;
using CloudSuite.Modules.Domain.Contracts;
using MediatR;
using System.Text.Json;
using Microsoft.Extensions.Logging;
using CloudSuite.Application.Validations;


namespace CloudSuite.Application.Handlers.Companies
{
    public class CheckCompanyExistsByCnpjAndFantasyNameAndSocialNameHandlers : IRequestHandler<CheckCompanyExistsByCnpjAndFantasyNameAndSocialNameRequest, CheckCompanyExistsByCnpjAndFantasyNameAndSocialNameResponse>
    {
        private ICompanyRepository _repositorioCompany;
        private readonly ILogger<CheckCompanyExistsByCnpjAndFantasyNameAndSocialNameHandlers> _logger;

        public CheckCompanyExistsByCnpjAndFantasyNameAndSocialNameHandlers(ICompanyRepository repositorioCompany, ILogger<CheckCompanyExistsByCnpjAndFantasyNameAndSocialNameHandlers> logger)
        {
            _repositorioCompany = repositorioCompany;
            _logger = logger;
        }

        public async Task<CheckCompanyExistsByCnpjAndFantasyNameAndSocialNameResponse> Handle(CheckCompanyExistsByCnpjAndFantasyNameAndSocialNameRequest request, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"CheckCompanyExistsByCnpjAndFantasyNameAndSocialNameRequest: {JsonSerializer.Serialize(request)}");
            var validationResult = new CheckCompanyExistsByCnpjAndFantasyNameAndSocialNameRequestValidation().Validate(request);

            if (validationResult.IsValid)
            {
                try
                {
                    var company = await _repositorioCompany.GetByCnpj(new Cnpj(request.Cnpj));
                    if (company != null)
                    {
                        return await Task.FromResult(new CheckCompanyExistsByCnpjAndFantasyNameAndSocialNameResponse(request.Id, true, validationResult));
                    }
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex.Message);
                    return await Task.FromResult(new CheckCompanyExistsByCnpjAndFantasyNameAndSocialNameResponse(request.Id, "It wasn`t possible to process your solicitaion."));
                }
            }

            return await Task.FromResult(new CheckCompanyExistsByCnpjAndFantasyNameAndSocialNameResponse(request.Id, false, validationResult));

        }
    }
}
