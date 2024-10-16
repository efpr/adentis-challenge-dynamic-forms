using DynamicForms.Application.CompanyUseCases.GetAll;
using FastEndpoints;
using MediatR;

namespace DynamicForms.Presentation.Endpoints
{
    public class GetAllCompanies(IMediator _mediator) : EndpointWithoutRequest<IEnumerable<GetAllCompaniesResponse>>
    {
        public const string Route = "/companies";
        private const string ERROR_MESSAGE = "An error occurred while obtaining the companies.";

        public override void Configure()
        {
            Get(Route);
            AllowAnonymous();
            Description(b => b
                .Produces<IEnumerable<GetAllCompaniesResponse>>()
            );
        }

        public override async Task<IEnumerable<GetAllCompaniesResponse>> HandleAsync(CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(new GetAllCompaniesCommand());

            if (!response.IsSuccess)
            {
                ThrowError(ERROR_MESSAGE);
            }

            Response = GetAllCompaniesResponse.ConvertAll(response.Value);

            return Response;
        }

    }
}