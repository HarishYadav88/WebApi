using Xunit;
using System.Net.Http;
using System.Threading.Tasks;
using WebApi.IntegrationTest;
using Newtonsoft.Json;
using WebApi.BusinessLayer.Models;
using System.Collections.Generic;


namespace WebApi.Test
{
    public class GroupControllerTest : IClassFixture<CustomWebApplicationFactory<Startup>>
    {
        private readonly HttpClient _client;

        public GroupControllerTest(CustomWebApplicationFactory<Startup> factory)
        {
            _client = factory.CreateClient();
        }

        [Fact]
        public async Task GetGroupsAsyncTest()
        {
            // The endpoint or route of the controller action.
            var response = await _client.GetAsync("/api/group");

            // Must be successful.
            response.EnsureSuccessStatusCode();

            // Deserialize and examine results.
            var stringResponse = await response.Content.ReadAsStringAsync();
            var groups = JsonConvert.DeserializeObject<IList<Group>>(stringResponse);

            Assert.Contains(groups, p => p.Name == "Group 1");
            Assert.Contains(groups, p => p.Name == "Group 2");

        }
    }
}