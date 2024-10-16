
namespace DynamicForms.Presentation.Endpoints
{
    public class CreateCompanyResponse(string id)
    {
        public string CompanyId { get; init; } = id;
    }
}
