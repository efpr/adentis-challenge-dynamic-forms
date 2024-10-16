using DynamicForms.Application.CompanyUseCases.Create;
using System.Reflection;

namespace DynamicForms.Presentation.Setup
{
    public static class MediatorSetup
    {
        public static IServiceCollection AddMediatorSetup(this IServiceCollection services)
        {
            var mediatRAssemblies = new[]
            {
                Assembly.GetAssembly(typeof(CreateCompanyCommand))
            };

            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(mediatRAssemblies!));

            return services;
        }
    }
}
