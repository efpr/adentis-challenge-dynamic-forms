using DynamicForms.Core.CompanyAggregator;
using DynamicForms.Presentation.Endpoints;
using Moq;
using System.Net;
using System.Net.Http.Json;

namespace AdentisChallenge.DynamicForms.API.Test
{
    public class CreateCompany
    {
        private Mock<ICompanyRepository> _mockRepository;
        private readonly HttpClient httpClient;

        private const string _route = "/companies";


        private readonly CreateCompanyRequest createCompanyRequest = new CreateCompanyRequest
        {
            Name = "Company ABC",
            FormFields = new List<CreateCompanyFieldsRequest>
            {
                new CreateCompanyFieldsRequest
                {
                    Label = "Field 1",
                    Type = "text",
                    Validation = new CreateCompanyValidationRequest
                    {
                        Required = true,
                        Pattern = "^[a-zA-Z0-9]*$"
                    }
                }
            }
        };

        private readonly Company company;

        public CreateCompany()
        {
            company = CreateCompanyRequest.MapToCompany(createCompanyRequest);
            
            SetupMockRepository();

#pragma warning disable CS8602 // Dereference of a possibly null reference.
            var api = new CompanyApiFactory(_mockRepository.Object);
#pragma warning restore CS8602 // Dereference of a possibly null reference.
            httpClient = api.CreateClient();

        }

        private void SetupMockRepository()
        {
            _mockRepository = new Mock<ICompanyRepository>();
            _mockRepository.Setup(x => x.AddAsync(company)).Returns(Task.CompletedTask);

            
            if (_mockRepository is null)
            {
                throw new ArgumentNullException(nameof(_mockRepository));
            }
        }

        [Fact]
        public async Task Should_return_201_created_When_send_company()
        {
            var response = await httpClient.PostAsJsonAsync(_route, company);

            Assert.Equal(HttpStatusCode.Created, response.StatusCode);
        }

        [Fact]
        public async Task Should_add_to_database_When_send_company()
        {
            var response = await httpClient.PostAsJsonAsync(_route, company);

            Assert.Equal(HttpStatusCode.Created, response.StatusCode);
            _mockRepository.Verify(x => x.AddAsync(It.Is<Company>(c => c.Name == "Company ABC")), Times.Once);
        }

        [Fact]
        public async Task Should_return_400_bad_request_When_send_invalid_company_name()
        {
            var company = new CreateCompanyRequest()
            {
                Name = string.Empty
            };

            var response = await httpClient.PostAsJsonAsync(_route, company);

            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }

        [Fact]
        public async Task Should_return_400_bad_request_When_send_invalid_company_form_fields_label_missing()
        {
            var company = new CreateCompanyRequest()
            {
                Name = "Company ABC",
                FormFields = new List<CreateCompanyFieldsRequest>
                {
                    new CreateCompanyFieldsRequest
                    {
                        Type = "text",
                    },
                }
            };

            var response = await httpClient.PostAsJsonAsync(_route, company);

            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }

        [Fact]
        public async Task Should_return_400_bad_request_When_send_invalid_company_form_fields_type_missing()
        {
            var company = new CreateCompanyRequest()
            {
                Name = "Company ABC",
                FormFields = new List<CreateCompanyFieldsRequest>
                {
                    new CreateCompanyFieldsRequest
                    {
                        Label = "Field 1",
                    },
                }
            };

            var response = await httpClient.PostAsJsonAsync(_route, company);

            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }

        [Fact]
        public async Task Should_return_400_bad_request_When_send_invalid_company_form_fields_type_invalid()
        {
            var company = new CreateCompanyRequest()
            {
                Name = "Company ABC",
                FormFields = new List<CreateCompanyFieldsRequest>
                {
                    new CreateCompanyFieldsRequest
                    {
                        Label = "Field 1",
                    },
                }
            };

            var response = await httpClient.PostAsJsonAsync(_route, company);

            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }
    }
}