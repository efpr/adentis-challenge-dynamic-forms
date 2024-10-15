using System.Net;
using System.Net.Http.Json;

namespace AdentisChallenge.DynamicForms.API.Test
{
    public class CreateCompany
    {
        [Fact]
        public async Task Should_return_201_Created()
        {
            var api = new CompanyApiFactory();
            var httpClient = api.CreateClient();

            var response = await httpClient.PostAsJsonAsync("/company", new
            {
                Name = "Company ABC"
            });

            Assert.Equal(HttpStatusCode.Created, response.StatusCode);
        }
    }
}