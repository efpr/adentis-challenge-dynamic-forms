using Ardalis.Result;
using Ardalis.SharedKernel;
using DynamicForms.Core.CompanyAggregator;

namespace DynamicForms.Application.CompanyUseCases.GetAll
{
    public class GetAllCompaniesHandler(ICompanyRepository _repository) : ICommandHandler<GetAllCompaniesCommand, Result<IEnumerable<Company>>>
    {

        private const string ERROR_MESSAGE = "An error occurred while interacting with the repository";

        public async Task<Result<IEnumerable<Company>>> Handle(GetAllCompaniesCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var companies = await _repository.GetAllAsync();
                return Result.Created(companies);

            }
            catch (Exception)
            {
                return Result.Error(ERROR_MESSAGE);
            }
        }
    }
}
