using DynamicForms.Core.CompanyAggregator;
using DynamicForms.Infrastructure.Configuration;
using DynamicForms.Infrastructure.Persistence;

namespace DynamicForms.Presentation.Setup
{
    public static class CompanyMongoRepositorySetup
    {
        public static WebApplicationBuilder AddCompanyMongoRepository(this WebApplicationBuilder builder)
        {
            builder.Services.Configure<MongoSettings>(builder.Configuration.GetSection("CompanyRepositorySettings"));
            builder.Services.AddSingleton<ICompanyRepository, CompanyMongoRepository>();

            return builder;
        }
    }
}
