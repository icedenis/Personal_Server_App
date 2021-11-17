using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Personal_Server_App.Models;
using Personal_Server_App.Interfaces;
using Blazored.LocalStorage;
using System.Net.Http;

namespace Personal_Server_App.Repos
{
    public class BookRepo : BaseRepo<BookModel>, IBookRepo
    {
        private readonly IHttpClientFactory _client;
        private readonly ILocalStorageService _localStorage;

        public BookRepo(IHttpClientFactory client, ILocalStorageService localStorage) : base(client, localStorage)
        {
            _client = client;
            _localStorage = localStorage;

        }



    }
}
