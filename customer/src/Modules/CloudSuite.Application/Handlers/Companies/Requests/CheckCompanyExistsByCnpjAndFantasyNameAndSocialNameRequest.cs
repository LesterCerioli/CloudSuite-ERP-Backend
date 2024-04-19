using CloudSuite.Application.Handlers.Companies.Responses;
using MediatR;

namespace CloudSuite.Application.Handlers.Companies.Requests
{
    public class CheckCompanyExistsByCnpjAndFantasyNameAndSocialNameRequest : IRequest<CheckCompanyExistsByCnpjAndFantasyNameAndSocialNameResponse>
    {
        public Guid Id {  get; private set; }

        public string? Cnpj {  get; set; }

        public string? SocialName { get; set; }

        public string? FantasyName {  get; set; }

        public CheckCompanyExistsByCnpjAndFantasyNameAndSocialNameRequest(Guid id, string? cnpj, string? socialName, string? fantasyName)
        {
            Id = Guid.NewGuid();
            Cnpj = cnpj;
            SocialName = socialName;
            FantasyName = fantasyName;
        }

        public CheckCompanyExistsByCnpjAndFantasyNameAndSocialNameRequest(string cnpj)
        {
            Cnpj = cnpj;
        }
    }
}
