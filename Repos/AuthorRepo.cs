using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Personal_Server_App.Interfaces;
using System.Net.Http;
using Personal_Server_App.Models;
using Blazored.LocalStorage;

namespace Personal_Server_App.Repos

{
    public class AuthorRepo : BaseRepo<AuthorModel>, IAuthoRepo
    {

        private readonly IHttpClientFactory _client;
        private readonly ILocalStorageService _localStorage;

        public AuthorRepo(IHttpClientFactory client, ILocalStorageService localStorage) : base(client,localStorage)
        {
            _client = client;
            _localStorage = localStorage;
        }

 
    }
}
