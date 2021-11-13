using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Personal_Server_App.Interfaces;
using Personal_Server_App.Models;
using Personal_Server_App.Connections;
using System.Text;
using Newtonsoft.Json;
using Blazored.LocalStorage;
using Personal_Server_App.Token;
using System.Net.Http.Headers;
using Microsoft.AspNetCore.Components.Authorization;

namespace Personal_Server_App.Repos
{
    public class AuthenticationRepo : IAuthenticationRepo
    {
      
        private readonly IHttpClientFactory _client;
        private readonly ILocalStorageService _localStorage;
        private readonly AuthenticationStateProvider _authenticationStateProvider;


        public AuthenticationRepo(IHttpClientFactory client , ILocalStorageService localStorage, AuthenticationStateProvider authenticationStateProvider)
        {
            _client = client;
            _localStorage = localStorage;
            _authenticationStateProvider = authenticationStateProvider;
        }

        public async Task<bool> Login(ModelLogin user)
        {
            var request = new HttpRequestMessage(HttpMethod.Post, Endpoint.LoginEndpoint);
            request.Content = new StringContent(JsonConvert.SerializeObject(user),
                Encoding.UTF8,
                "application/json");

            var client = _client.CreateClient();
            HttpResponseMessage responselink = await client.SendAsync(request);
            //here i add the token as well
     


          if(responselink.IsSuccessStatusCode == false)
            {
                return false;
            }
            var data = await responselink.Content.ReadAsStringAsync();
  
            var token = JsonConvert.DeserializeObject<TokenJWT>(data);
            // save token
            await _localStorage.SetItemAsync("Token", token.Token);
            await ((TokenAuthen)_authenticationStateProvider).LoggedIn();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", token.Token);
            return true;


        }

        public  async Task Logout()
        {
            await _localStorage.RemoveItemAsync("Token");
            ((TokenAuthen)_authenticationStateProvider).LoggedOut();
        }

        public async Task<bool> Register(Register_Personal user)
        {
            var request = new HttpRequestMessage(HttpMethod.Post, Endpoint.RegisterEndpoint);
            request.Content = new StringContent(JsonConvert.SerializeObject(user), 
                Encoding.UTF8, 
                "application/json");

            var client = _client.CreateClient();
            HttpResponseMessage response = await client.SendAsync(request);

            return response.IsSuccessStatusCode;
        }
    }
}
