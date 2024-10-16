
namespace DynamicForms.Core.CompanyAggregator
{
    public interface ICompanyRepository
    {
        Task AddAsync(Company entity);
        Task<Company> GetByIdAsync(string id);

        Task<IEnumerable<Company>> GetAllAsync();
    }
}
