
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using System.Reflection;
using cf = CrowdfundingApi.CrowdfundingApi;
using BLL.Models;
using System.Net;
using System.Text.Json;

namespace Test {

    [TestClass]
    public class StatusUnitTest {

        private List<StatusBll> status = new List<StatusBll>() {
            new StatusBll(){ Id = 1, TypeStatus = "Submit" },
            new StatusBll(){ Id = 2, TypeStatus = "Accept" },
            new StatusBll(){ Id = 3, TypeStatus = "Refused" },
            new StatusBll(){ Id = 4, TypeStatus = "Encours" },
            new StatusBll(){ Id = 5, TypeStatus = "Deleted" },
            new StatusBll(){ Id = 6, TypeStatus = "Finished" },
        };

        [TestMethod]
        public async Task GetAllProjetStatue() {

            await using var application = new WebApplicationFactory<cf>();
            using var client = application.CreateClient();

            //var response = await client.GetStringAsync("/api/StatusProjet");
            var response = await client.GetAsync("/api/StatusProjet");

            var options = new JsonSerializerOptions();
            options.PropertyNameCaseInsensitive = true;

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            string json = await response.Content.ReadAsStringAsync();
            List<StatusBll> r = JsonSerializer.Deserialize<List<StatusBll>>(json, options);

            for (int i = 0; i < status.Count; i++) {
                Assert.AreEqual(status[i].Id, r[i].Id);
                Assert.AreEqual(status[i].TypeStatus, r[i].TypeStatus);
            }

        }

    }
}




















