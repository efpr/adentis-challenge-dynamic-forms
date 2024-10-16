using DynamicForms.Core.CompanyAggregator;

namespace DynamicForms.Presentation.Endpoints
{
    public class GetCompanyByIdResponse
    {
        public string Name { get; set; } = string.Empty;

        public IEnumerable<GetCompanyFieldsResponse> FormFields { get; set; } = new List<GetCompanyFieldsResponse>();

        public static GetCompanyByIdResponse FromCompany(Company company)
        {
            return new GetCompanyByIdResponse()
            {
                Name = company.Name,
                FormFields = MapToCompanyFields(company.FormFields)
            };
        }

        private static IEnumerable<GetCompanyFieldsResponse> MapToCompanyFields(IEnumerable<CompanyFields> formfields)
        {
            return formfields.Select(x => new GetCompanyFieldsResponse
            {
                Label = x.Label,
                Type = x.Type,
#pragma warning disable CS8604 // The validation is present inside the method
                Validation = MapToValidation(x.Validation),
#pragma warning restore CS8604
                Options = x.Options
            });
        }

        private static GetCompanyValidationResponse? MapToValidation(Validation validation)
        {
            if (validation == null)
            {
                return null;
            }

            return new GetCompanyValidationResponse
            {
                Required = validation.Required,
                Pattern = validation.Pattern
            };
        }
    }
    
}
