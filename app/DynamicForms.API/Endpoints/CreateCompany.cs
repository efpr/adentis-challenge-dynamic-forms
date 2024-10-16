using DynamicForms.Application.CompanyUseCases.Create;
using FastEndpoints;
using MediatR;

namespace DynamicForms.Presentation.Endpoints
{
    public class CreateCompany(IMediator _mediator) : Endpoint<CreateCompanyRequest, CreateCompanyResponse>
    {
        public const string Route = "/companies";
        private const string ERROR_MESSAGE = "An error occurred while creating the company";

        public override void Configure()
        {
            Post(Route);
            AllowAnonymous();
            Description(b => b
                .Accepts<CreateCompanyRequest>()
                .Produces<CreateCompanyResponse>()
            );
        }

        public override async Task<CreateCompanyResponse> HandleAsync(CreateCompanyRequest request, CancellationToken cancellationToken)
        {
            var company = CreateCompanyRequest.MapToCompany(request);

            var response = await _mediator.Send(new CreateCompanyCommand(company));

            if (!response.IsSuccess)
            {
                ThrowError(ERROR_MESSAGE);
            }

            Response = new CreateCompanyResponse(response.Value);
            await SendCreatedAtAsync($"{Route}/{response.Value}", response.Value, Response, false, cancellationToken);

            return Response;
        }

    }
}
