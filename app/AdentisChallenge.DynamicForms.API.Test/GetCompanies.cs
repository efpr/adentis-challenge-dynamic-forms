using DynamicForms.Core.CompanyAggregator;
using DynamicForms.Presentation.Endpoints;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace AdentisChallenge.DynamicForms.API.Test
{
    public class GetCompanies
    {
        private Mock<ICompanyRepository> _mockRepository;
        private readonly HttpClient httpClient;

        private const string _route = "/companies";

        private readonly IEnumerable<Company> companies = new List<Company>()
        {
            new Company {Id = "1", Name = "Company ABC" },
            new Company {Id = "2", Name = "Company XYZ" }
        };

        public GetCompanies()
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
            _mockRepository.Setup(x => x.GetAllAsync()).Returns(Task.FromResult(companies));


            if (_mockRepository is null)
            {
                throw new ArgumentNullException(nameof(_mockRepository));
            }
        }

        [Fact]
        public async Task Should_return_200_When_retrieve_companies()
        {
            var response = await httpClient.GetAsync(_route);

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }
    }
}
