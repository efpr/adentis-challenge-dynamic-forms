using DynamicForms.Core.CompanyAggregator;

namespace DynamicForms.Presentation.Endpoints
{
    public class GetAllCompaniesResponse(string Id, string Name)
    {
        public string Id { get; } = Id;
        public string Name { get; } = Name;

        public static IEnumerable<GetAllCompaniesResponse> ConvertAll(IEnumerable<Company> companies) =>
            companies.Select(x => new GetAllCompaniesResponse(x.Id, x.Name));
    }
   
}
