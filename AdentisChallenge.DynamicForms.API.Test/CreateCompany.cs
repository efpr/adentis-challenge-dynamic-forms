using DynamicForms.Core.CompanyAggregator;
using DynamicForms.Core.Domain;
using MongoDB.Driver;
using Moq;
using System.Net;
using System.Net.Http.Json;

namespace AdentisChallenge.DynamicForms.API.Test
{
    public class CreateCompany
    {
        private readonly Mock<ICompanyRepository> mockRepository;
        private readonly HttpClient httpClient;

        private const string _route = "/companies";

        private readonly Company company = new Company
        {
            Name = "Company ABC"
        };

        public CreateCompany()
        {
            mockRepository = new Mock<ICompanyRepository>();
            mockRepository.Setup(x => x.AddAsync(company)).Returns(Task.CompletedTask);
            
            var api = new CompanyApiFactory(mockRepository.Object);

            httpClient = api.CreateClient();

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
            mockRepository.Verify(x => x.AddAsync(It.Is<Company>(c => c.Name == "Company ABC")), Times.Once);
        }
    }
}