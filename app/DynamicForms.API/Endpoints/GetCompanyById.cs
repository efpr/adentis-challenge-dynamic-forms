using Ardalis.Result;
using DynamicForms.Application.CompanyUseCases.GetById;
using FastEndpoints;
using MediatR;
using System.Net;

namespace DynamicForms.Presentation.Endpoints
{
    public class GetCompanyById(IMediator _mediator) : Endpoint<GetCompanyByIdRequest, GetCompanyByIdResponse>
    {
        public const string Route = "/companies/{id}";
        private const string ERROR_MESSAGE = "An error occurred while creating the company";

        public override void Configure()
        {
            Get(Route);
            AllowAnonymous();
            Description(b => b
                .Accepts<GetCompanyByIdRequest>()
                .Produces<GetCompanyByIdResponse>()
            );
        }

        public override async Task<GetCompanyByIdResponse> HandleAsync(GetCompanyByIdRequest request, CancellationToken cancellationToken)
        {

            var response = await _mediator.Send(new GetCompanyByIdCommand(request.Id));

            if (response.Status == ResultStatus.NotFound)
            {
                ThrowError(ERROR_MESSAGE, (int)HttpStatusCode.NotFound);
            }
            
            if (!response.IsSuccess)
            {
                ThrowError(ERROR_MESSAGE);
            }


            Response = GetCompanyByIdResponse.FromCompany(response.Value);
            return Response;
        }

    }
}
