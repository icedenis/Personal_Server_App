using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Personal_Server_App.Interfaces;
using System.Text;
using Blazored.LocalStorage;

namespace Personal_Server_App.Repos
{
    public class BaseRepo <T> : IBaseRepo<T> where T : class
    {

        private readonly IHttpClientFactory _client;
        private readonly ILocalStorageService _localStorage;

        public BaseRepo(IHttpClientFactory client, ILocalStorageService localStorage)
        {
            _client = client;
            _localStorage = localStorage;
        }


        public async Task<T> Get(string url, int id)
        {
            var requestlink = new HttpRequestMessage(HttpMethod.Get, url + id);
            if (id < 1)
            {
                return null;
            }
       //     requestlink.Content = new StringContent(JsonConvert.SerializeObject(tmp));
            var client = _client.CreateClient();
            HttpResponseMessage responselink = await client.SendAsync(requestlink);
            if (responselink.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var data = await responselink.Content.ReadAsStringAsync();
                // here i return the content
                return JsonConvert.DeserializeObject<T>(data);
            }
            return null;
        }

        public async Task<IList<T>> GetAll(string url)
        {
            var requestlink = new HttpRequestMessage(HttpMethod.Get, url);
       
            //     requestlink.Content = new StringContent(JsonConvert.SerializeObject(tmp));
            var client = _client.CreateClient();
            HttpResponseMessage responselink = await client.SendAsync(requestlink);
            if (responselink.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var data = await responselink.Content.ReadAsStringAsync();
                // here i return the content of the list
                return JsonConvert.DeserializeObject<IList<T>>(data);
            }
            return null;
        }

        public async Task<bool> Create(string url, T tmp)
        {
            var requestlink = new HttpRequestMessage(HttpMethod.Post, url);
            if(tmp == null)
            {
                return false;
            }
            requestlink.Content = new StringContent(JsonConvert.SerializeObject(tmp)
            , Encoding.UTF8, "application/json");
            var client = _client.CreateClient();
            HttpResponseMessage responselink = await client.SendAsync(requestlink);
            if (responselink.StatusCode == System.Net.HttpStatusCode.Created)
            {
                return true;
            }
            return false;

        }

        public async Task<bool> Update(string url, T tmp , int id)
        {
            var requestlink = new HttpRequestMessage(HttpMethod.Put, url+id);
            if (tmp == null)
            {
                return false;
            }
            requestlink.Content = new StringContent(JsonConvert.SerializeObject(tmp)
                ,Encoding.UTF8,"application/json");
            var client = _client.CreateClient();
            HttpResponseMessage responselink = await client.SendAsync(requestlink);
            if (responselink.StatusCode == System.Net.HttpStatusCode.NoContent)
            {
                return true;
            }
            return false;
        }

        public async Task<bool> Delete(string url, int id)
        {
            var requestlink = new HttpRequestMessage(HttpMethod.Delete, url + id);
            if (id < 1)
            {
                return false;
            }
          //  requestlink.Content = new StringContent(JsonConvert.SerializeObject(tmp));
            var client = _client.CreateClient();
            HttpResponseMessage responselink = await client.SendAsync(requestlink);
            if (responselink.StatusCode == System.Net.HttpStatusCode.NoContent)
            {
                return true;
            }
            return false;
        }

   

    }
    
}
