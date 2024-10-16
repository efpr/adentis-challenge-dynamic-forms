using FastEndpoints;
using FluentValidation;

namespace DynamicForms.Presentation.Endpoints
{
    public class CreateCompanyValidator : Validator<CreateCompanyRequest>
    {
        public CreateCompanyValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessage("Name is required.");
        }
    }
}
