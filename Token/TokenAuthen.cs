using Microsoft.AspNetCore.Components.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blazored.LocalStorage;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;

namespace Personal_Server_App.Token
{
    public class TokenAuthen : AuthenticationStateProvider
    {
        private readonly ILocalStorageService _localStorage;
        private readonly JwtSecurityTokenHandler _tokenHandler;

        public TokenAuthen(ILocalStorageService localStorage , JwtSecurityTokenHandler tokenHandler)
        {
            _localStorage = localStorage;
            _tokenHandler = tokenHandler;
        }
        public async  override Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            try
            {
                var token = await _localStorage.GetItemAsync<string>("Token");
                //if token is empty
                if (string.IsNullOrEmpty(token))
                {
                    return new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity()));

                }
                // here i read the token data with the help of identity mode token jwt same as the exple in plural
                var tokendata = _tokenHandler.ReadJwtToken(token);
                var EndDate = tokendata.ValidTo;
                if(EndDate < DateTime.Now)
                {
                    await _localStorage.RemoveItemAsync("Token");
                    return new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity()));
                }
                // here is the user object
                var claimList = ClaimList(tokendata);
                var user = new ClaimsPrincipal(new ClaimsIdentity(claimList, "jwt"));
                return new AuthenticationState(user);

            }
            catch
            {
                // i just log everyone out so program dont crash
                return new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity()));
            }

       
        }
        public async Task LoggedIn()
        {
            var token = await _localStorage.GetItemAsync<string>("Token");
            var tokenData = _tokenHandler.ReadJwtToken(token);
            var claimlist = ClaimList(tokenData);
            var user = new ClaimsPrincipal(new ClaimsIdentity(claimlist, "jwt"));
            var authenStatus = Task.FromResult(new AuthenticationState(user));
            NotifyAuthenticationStateChanged(authenStatus);
        }

        public void LoggedOut()
        {
            var noOne = new ClaimsPrincipal(new ClaimsIdentity());
            var authStatus = Task.FromResult(new AuthenticationState(noOne));
            NotifyAuthenticationStateChanged(authStatus);
        }




        private IList<Claim> ClaimList(JwtSecurityToken tokenData)
        {
            var claimlist = tokenData.Claims.ToList();
            claimlist.Add(new Claim(ClaimTypes.Name, tokenData.Subject));
            return claimlist;
        }

    }
}
