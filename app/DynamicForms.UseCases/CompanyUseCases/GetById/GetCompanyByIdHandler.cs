using Ardalis.Result;
using Ardalis.SharedKernel;
using DynamicForms.Core.CompanyAggregator;

namespace DynamicForms.Application.CompanyUseCases.GetById
{
    public class GetCompanyByIdHandler(ICompanyRepository _repository) : ICommandHandler<GetCompanyByIdCommand, Result<Company>>
    {

        private const string ERROR_MESSAGE = "An error occurred while interacting with the repository";

        public async Task<Result<Company>> Handle(GetCompanyByIdCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var company = await _repository.GetByIdAsync(request.id);

                if (company == null)
                {
                    return Result.NotFound();
                }

                return Result.Created(company);

            }
            catch (Exception)
            {
                return Result.Error(ERROR_MESSAGE);
            }
        }
    }
}
