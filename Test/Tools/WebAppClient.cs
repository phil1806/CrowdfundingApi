using BLL.Models;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.Options;
using System.IO;
using System.Net;
using System.Net.Http.Json;
using System.Text.Json;

namespace Test.Tools {
    public class WebAppClient<T> where T : class {

        private readonly string BaseURL;
        private readonly JsonSerializerOptions Options;


        public WebAppClient(string baseURL) {
            BaseURL = baseURL;
            Options = new JsonSerializerOptions();
            Options.PropertyNameCaseInsensitive = true;
        }

        public async Task<R> SendGet<R>(string path = "") {
            await using WebApplicationFactory<T> application = new WebApplicationFactory<T>();
            using var client = application.CreateClient();
            HttpResponseMessage response = await client.GetAsync(BaseURL + path);         
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode, " status code for get is not 200 ");
            string json = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<R>(json, Options);
        }

        public async Task<R> SendPost<R,D>(D data,string path = "") {
            await using WebApplicationFactory<T> application = new WebApplicationFactory<T>();
            using var client = application.CreateClient();
            HttpResponseMessage response = await client.PostAsJsonAsync<D>(BaseURL + path,data);
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode, " status code for post is not 200 ");
            string json = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<R>(json, Options);
        }

        public async Task SendPost<D>(D data, string path = "") {
            await using WebApplicationFactory<T> application = new WebApplicationFactory<T>();
            using var client = application.CreateClient();
            HttpResponseMessage response = await client.PostAsJsonAsync<D>(BaseURL + path, data);;
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode, " status code for post is not 200 ");
        }

        public async Task SendDelete(string path = "") {
            await using WebApplicationFactory<T> application = new WebApplicationFactory<T>();
            using var client = application.CreateClient();
            HttpResponseMessage response = await client.DeleteAsync(BaseURL + path);
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode, " status code for delete is not 200 ");
        }

        public async Task SendUpdate<D>(D data, string path = "") {
            await using WebApplicationFactory<T> application = new WebApplicationFactory<T>();
            using var client = application.CreateClient();
            HttpResponseMessage response = await client.PutAsJsonAsync<D>(BaseURL + path,data);
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode, " status code for update is not 200 ");
        }

    }
}
