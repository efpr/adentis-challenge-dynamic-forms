using FastEndpoints;
using FluentValidation;

namespace DynamicForms.Presentation.Endpoints
{
    public class CreateCompanyValidator : Validator<CreateCompanyRequest>
    {
        public CreateCompanyValidator()
        {
            CheckNameIsProvided();
            EnsureFormFieldsArePresent();
            ValidateFormFields();
        }

        private void ValidateFormFields()
        {
            RuleForEach(x => x.FormFields)
                .SetValidator(new CreateCompanyFieldsRequestValidator());
        }

        private void EnsureFormFieldsArePresent()
        {
            RuleFor(x => x.FormFields)
                .NotEmpty()
                .WithMessage("Form fields are required.");
        }

        private void CheckNameIsProvided()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessage("Name is required.");
        }
    }
}
