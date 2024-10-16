using Ardalis.Result;
using Ardalis.SharedKernel;
using DynamicForms.Core.CompanyAggregator;

namespace DynamicForms.Application.CompanyUseCases.GetAll
{
    public record GetAllCompaniesCommand() :ICommand<Result<IEnumerable<Company>>>;

}
