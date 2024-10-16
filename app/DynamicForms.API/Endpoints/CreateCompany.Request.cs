using DynamicForms.Core.Domain;

namespace DynamicForms.Presentation.Endpoints
{
    public class CreateCompanyRequest
    {
        public string Name { get; set; } = string.Empty;

        public static Company MapToCompany(CreateCompanyRequest request)
        {         
            return new Company
            {
                Name = request.Name
            };
        }
    }
}
