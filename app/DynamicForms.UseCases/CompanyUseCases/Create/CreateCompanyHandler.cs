using Ardalis.Result;
using Ardalis.SharedKernel;
using DynamicForms.Core.CompanyAggregator;
using DynamicForms.Core.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicForms.Application.CompanyUseCases.Create
{
    public class CreateCompanyHandler(ICompanyRepository _repository) : ICommandHandler<CreateCompanyCommand, Result<string>>
    {
        private const string ERROR_MESSAGE = "An error occurred while interacting with the repository";

        public async Task<Result<string>> Handle(CreateCompanyCommand request, CancellationToken cancellationToken)
        {
            try
            {
                request.company.SetNewId();
                await _repository.AddAsync(request.company);
            }
            catch(Exception)
            {
                return Result.Error(ERROR_MESSAGE);
            }

            return Result.Created(request.company.Id);
        }
    }
}
