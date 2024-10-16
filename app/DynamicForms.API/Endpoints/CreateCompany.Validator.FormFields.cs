using FastEndpoints;
using FluentValidation;

namespace DynamicForms.Presentation.Endpoints
{
    public class CreateCompanyFieldsRequestValidator : Validator<CreateCompanyFieldsRequest>
    {
        public CreateCompanyFieldsRequestValidator()
        {
            LabelMustExist();
            TypeMustBeValid();
        }

        private void TypeMustBeValid()
        {
            TypeIsRequired();
            // Move the rule to check if the type is valid to the use case,
            // so the validator is only responsible for checking if the field is present.
        }

        private IRuleBuilderOptions<CreateCompanyFieldsRequest, string> TypeIsRequired()
        {
            return RuleFor(x => x.Type)
                .NotEmpty().WithMessage("Type is required.");
        }

        private void LabelMustExist()
        {
            RuleFor(x => x.Label)
                .NotEmpty()
                .WithMessage("Label is required.");
        }
    }
}
