using DynamicForms.Core.CompanyAggregator;
using DynamicForms.Presentation;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;

namespace AdentisChallenge.DynamicForms.API.Test
{
    internal class CompanyApiFactory: WebApplicationFactory<IApiAssemblyMarker>
    {
        private readonly ICompanyRepository _companyRepository;

        public CompanyApiFactory(ICompanyRepository companyRepository)
        {
            _companyRepository = companyRepository;
        }

        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.ConfigureServices(services =>
            {
                services.AddSingleton(_companyRepository);
            });
        }
    }
}
