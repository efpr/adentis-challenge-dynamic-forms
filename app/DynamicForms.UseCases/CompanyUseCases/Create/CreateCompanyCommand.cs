using Ardalis.Result;
using Ardalis.SharedKernel;
using DynamicForms.Core.CompanyAggregator;

namespace DynamicForms.Application.CompanyUseCases.Create
{
    public record CreateCompanyCommand(Company company): ICommand<Result<string>>;
}
