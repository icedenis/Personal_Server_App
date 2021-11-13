using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Personal_Server_App.Interfaces;
using System.Net.Http;
using Personal_Server_App.Models;
namespace Personal_Server_App.Repos

{
    public class AuthorRepo : BaseRepo<AuthorModel>, IAuthoRepo
    {

        private readonly IHttpClientFactory _client;

        public AuthorRepo(IHttpClientFactory client) : base(client)
        {
            _client = client;
        }

 
    }
}
