using FastEndpoints;
using FastEndpoints.Swagger;
using Microsoft.OpenApi.Models;

namespace DynamicForms.Presentation.Setup
{
    public static class SwaggerSetup
    {
        public static IServiceCollection AddSwaggerSetup(this IServiceCollection services)
        {
            services.AddFastEndpoints().SwaggerDocument(c =>
            {
                c.DocumentSettings = s =>
                {
                    s.Title = "DynamicForms API";
                    s.Version = "v1";
                    s.Description = "API for DynamicForms";
                };
            });

            return services;
        }
    }
}
