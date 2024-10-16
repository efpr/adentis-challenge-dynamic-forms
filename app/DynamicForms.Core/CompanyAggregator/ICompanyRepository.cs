
namespace DynamicForms.Core.CompanyAggregator
{
    public interface ICompanyRepository
    {
        Task AddAsync(Company entity);
        Task<Company> GetByIdAsync(string id);
    }
}
