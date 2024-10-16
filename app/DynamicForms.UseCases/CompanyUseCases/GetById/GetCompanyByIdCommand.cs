using Ardalis.Result;
using Ardalis.SharedKernel;
using DynamicForms.Core.CompanyAggregator;

namespace DynamicForms.Application.CompanyUseCases.GetById
{
    public record GetCompanyByIdCommand(string id) : ICommand<Result<Company>>;
    
}
