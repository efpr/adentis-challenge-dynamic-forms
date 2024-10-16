using DynamicForms.Core.CompanyAggregator;
using DynamicForms.Presentation.Endpoints;
using Microsoft.AspNetCore.Mvc.Filters;
using Moq;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace AdentisChallenge.DynamicForms.API.Test
{
    public class GetAllCompanies
    {
        private Mock<ICompanyRepository> _mockRepository;
        private readonly HttpClient httpClient;

        private const string _route = "/companies";

        private readonly IList<Company> companies = new List<Company>()
        {
            new Company {Id = "1", Name = "Company ABC" },
            new Company {Id = "2", Name = "Company XYZ" }
        };

        public GetAllCompanies()
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
            _mockRepository.Setup(x => x.GetAllAsync()).ReturnsAsync(companies);


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

        [Fact]
        public async Task Should_return_companies_When_retrieve_companies()
        {
            var response = await httpClient.GetAsync(_route);
            var bodyResponse = await GetResponseBody(response);

            Assert.NotNull(bodyResponse);
            Assert.Equal(companies.Count, bodyResponse.Count());

            for (int i = 0; i < companies.Count; i++)
            {
                Assert.Equal(companies[i].Id, bodyResponse.ElementAt(i).Id);
                Assert.Equal(companies[i].Name, bodyResponse.ElementAt(i).Name);
            }
        }

        private async Task<IEnumerable<GetAllCompaniesResponse>?> GetResponseBody(HttpResponseMessage response)
        {
            var content = await response.Content.ReadAsStringAsync();
            if (content == null)
            {
                Assert.Fail("Response content is null");
            }

            var bodyResponse = JsonConvert.DeserializeObject<IEnumerable<GetAllCompaniesResponse>>(content);
            if (bodyResponse == null)
            {
                Assert.Fail("Response body is null");
            }

            return bodyResponse;
        }
    }
}
