using Ardalis.Result;
using Ardalis.SharedKernel;
using DynamicForms.Core.CompanyAggregator;
using DynamicForms.Core.Exceptions;
using DynamicForms.Core.ValueObj;

namespace DynamicForms.Application.CompanyUseCases.Create
{
    public class CreateCompanyHandler(ICompanyRepository _repository) : ICommandHandler<CreateCompanyCommand, Result<string>>
    {
        private const string ERROR_MESSAGE = "An error occurred while interacting with the repository";

        public async Task<Result<string>> Handle(CreateCompanyCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var company = PrepareCompany(request.company);

                await _repository.AddAsync(request.company);
            }
            catch (InvalidTypeException ex)
            {
                return Result.Error(ex.Message);
            }
            catch (Exception)
            {
                return Result.Error(ERROR_MESSAGE);
            }

            return Result.Created(request.company.Id);
        }

        private Company PrepareCompany(Company company)
        {
            company.SetNewId();
            ValidateFormFieldsTypes(company);

            return company;
        }

        private void ValidateFormFieldsTypes(Company company)
        {
            var validTypes = company.FormFields.All(field => IsValidType(field.Type));

            if (!validTypes)
            {
                throw new InvalidTypeException();
            }
        }

        private bool IsValidType(string type)
        {
            type = type.ToLower();

            var result = InputTypes.AllowedTypes.ContainsKey(type);

            return result;
        }
    }
}
