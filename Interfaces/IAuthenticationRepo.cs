using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Personal_Server_App.Models;

namespace Personal_Server_App.Interfaces
{
    interface IAuthenticationRepo
    {
        public Task<bool> Register(Register_Personal user);
        public Task<bool> Login(ModelLogin user);
        public Task  Logout();
    }
}
