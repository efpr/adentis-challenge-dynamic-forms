using DynamicForms.Core.CompanyAggregator;
using DynamicForms.Presentation.Endpoints;
using Moq;
using Newtonsoft.Json;
using System.Net;

namespace AdentisChallenge.DynamicForms.API.Test
{
    public class GetCompanyByID
    {
        private Mock<ICompanyRepository> _mockRepository;
        private readonly HttpClient httpClient;

        private readonly Company _company = new Company { Id = "1", Name = "Company ABC" };
        private const string _route = "/companies/1";

        public GetCompanyByID()
        {
            SetupMockRepository();

#pragma warning disable CS8602 // Dereference of a possibly null reference.
            var api = new CompanyApiFactory(_mockRepository.Object);
#pragma warning restore CS8602 // Dereference of a possibly null reference.
            httpClient = api.CreateClient();

        }

        private void SetupMockRepository()
        {
            _mockRepository = new Mock<ICompanyRepository>();
            _mockRepository.Setup(x => x.GetByIdAsync(_company.Id)).ReturnsAsync(_company);


            if (_mockRepository is null)
            {
                throw new ArgumentNullException(nameof(_mockRepository));
            }
        }

        [Fact]
        public async Task Should_return_200_When_retrieve_company()
        {
            var response = await httpClient.GetAsync(_route);

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Fact]
        public async Task Should_return_company_When_retrieve_company()
        {
            var response = await httpClient.GetAsync(_route);
            var bodyResponse = await GetResponseBody(response);

            Assert.NotNull(bodyResponse);
            Assert.Equal(_company.Name, bodyResponse.Name);
        }

        [Fact]
        public async Task Should_return_404_When_company_not_found()
        {
            var route = "/companies/2";
            var response = await httpClient.GetAsync(route);

            Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
        }

        private async Task<GetCompanyByIdResponse> GetResponseBody(HttpResponseMessage response)
        {
            var content = await response.Content.ReadAsStringAsync();
            if (content == null)
            {
                Assert.Fail("Response content is null");
            }

            var bodyResponse = JsonConvert.DeserializeObject<GetCompanyByIdResponse>(content);
            if (bodyResponse == null)
            {
                Assert.Fail("Response body is null");
            }

            return bodyResponse;
        }
    }
}
