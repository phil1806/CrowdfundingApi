
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using System.Reflection;
using cf = CrowdfundingApi.CrowdfundingApi;
using BLL.Models;
using System.Net;
using System.Text.Json;
using System.Net.Http.Json;
using Microsoft.Extensions.Options;
using Test.ExtModels;
using Test.Tools;

namespace Test {

    [TestClass]
    public class StatusUnitTest {

        private WebAppClient<cf> Client = new WebAppClient<cf>("/api/StatusProjet");

        private List<StatusBll> status = new List<StatusBll>() {
            new StatusBll(){ Id = 1, TypeStatus = "Submit" },
            new StatusBll(){ Id = 2, TypeStatus = "Accept" },
            new StatusBll(){ Id = 3, TypeStatus = "Refused" },
            new StatusBll(){ Id = 4, TypeStatus = "Encours" },
            new StatusBll(){ Id = 5, TypeStatus = "Deleted" },
            new StatusBll(){ Id = 6, TypeStatus = "Finished" }
        };

        private StatusBll ToAdd = new StatusBll() { Id = 1, TypeStatus = "Test" };
        private StatusBll ToUpdate = new StatusBll() { Id = 1, TypeStatus = "TestUpadted" };

        [TestMethod]
        public async Task GetAllProjetStatue() {

            List<StatusBll> r = await Client.SendGet<List<StatusBll>>();

            if(status.Count > r.Count) {
                Assert.Fail($" Projet status list too short wait at least {status.Count} get {r.Count} ");
                return;
            }

            for (int i = 0; i < status.Count; i++) {
                Console.WriteLine($" {r[i].Id} => {r[i].TypeStatus} ");
                if (!status[i].Comparre(r[i])) {
                    Assert.Fail($" Projet status doesn't match");
                    return;
                }
            }

        }

        [TestMethod]
        public async Task AddupdateAndDeleteProjetStatue() {

            //Send 'ToAdd' to API
            await Client.SendPost(ToAdd);
            Console.WriteLine("Status to add sent => OK");

            //GetAll the status and check last is the last added
            List<StatusBll> r = await Client.SendGet<List<StatusBll>>();
            if (r.Last().TypeStatus != ToAdd.TypeStatus) {
                Assert.Fail($" last status is not what was sent");
                return;
            }
            Console.WriteLine($"last statu project before update last ID : {r.Last().Id}  => name : {r.Last().TypeStatus}");

            //Update last status
            string newName = "TestUpdate";
            StatusBll updated = new StatusBll() { Id = r.Last().Id, TypeStatus = newName };
            await UpdateProjetStatue(updated);

            //GetAll the status and check last has been updated 
            r = await Client.SendGet<List<StatusBll>>();
            if( r.Last().TypeStatus != newName) {
                Assert.Fail($" last status has not been updated");
                return;
            }
            int sizeList = r.Count;
            int romovedId = r.Last().Id;
            Console.WriteLine($"count status project before delete : {sizeList} => last ID : {r.Last().Id}  => name : {r.Last().TypeStatus}");

            //Delete the last statu
            await DeleteProjetStatue(r.Last());

            //GetAll status and check size -= 1 and last one is not 
            r = await Client.SendGet<List<StatusBll>>();
            Console.WriteLine($" size after delete {r.Count}");
            if (r.Count != sizeList - 1) {
                Assert.Fail($" list of status is not size-=1 after delete");
                return;
            }
            if( r.Exists(s => s.Id == romovedId) ) {
                Assert.Fail($"Deleted ID in the list after delete");
                return;
            }

        }

        public async Task UpdateProjetStatue(StatusBll s) {
            await Client.SendUpdate(s);
            Console.WriteLine("statue code update : OK");
        }

        public async Task DeleteProjetStatue(StatusBll s) {
            await Client.SendDelete("?id=" + s.Id);
            Console.WriteLine("statue code delete : OK");
        }

    }
}




















