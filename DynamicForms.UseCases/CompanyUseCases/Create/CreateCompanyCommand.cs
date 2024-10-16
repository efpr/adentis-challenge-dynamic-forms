using Ardalis.Result;
using Ardalis.SharedKernel;
using DynamicForms.Core.Domain;

namespace DynamicForms.Application.CompanyUseCases.Create
{
    public record CreateCompanyCommand(Company company): ICommand<Result<string>>;
}
