using DynamicForms.Core.CompanyAggregator;

namespace DynamicForms.Presentation.Endpoints
{
    public class CreateCompanyRequest
    {
        public string Name { get; set; } = string.Empty;

        public IEnumerable<CreateCompanyFieldsRequest> FormFields { get; set; } = new List<CreateCompanyFieldsRequest>();


        public static Company MapToCompany(CreateCompanyRequest request)
        {         
            return new Company
            {
                Name = request.Name,
                FormFields = MapToCompanyFields(request.FormFields)
            };
        }

        private static IEnumerable<CompanyFields> MapToCompanyFields(IEnumerable<CreateCompanyFieldsRequest> formfields)
        {
            return formfields.Select(x => new CompanyFields
            {
                Label = x.Label,
                Type = x.Type,
#pragma warning disable CS8604 // The validation is present inside the method
                Validation = MapToValidation(x.Validation),
#pragma warning restore CS8604
                Options = x.Options
            });
        }

        private static Validation? MapToValidation(CreateCompanyValidationRequest validation)
        {
            if (validation == null)
            {
                return null;
            }

            return new Validation
            {
                Required = validation.Required,
                Pattern = validation.Pattern
            };
        }
    }

}
