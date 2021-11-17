using BlazorStrap;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Components;

using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Personal_Server_App.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Personal_Server_App.Interfaces;
using Personal_Server_App.Repos;
using Blazored.LocalStorage;
using System.IdentityModel.Tokens.Jwt;
using Personal_Server_App.Token;
using Microsoft.AspNetCore.Components.Authorization;
using System.Net.Http;

namespace Personal_Server_App
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRazorPages();
            services.AddServerSideBlazor();
            services.AddSingleton<WeatherForecastService>();
            services.AddBootstrapCss();
            services.AddHttpClient();
            // here i add the authetication repo as well
            services.AddTransient<IAuthenticationRepo, AuthenticationRepo>();
            // same for intface Iauthor and AuthorRepo
            services.AddTransient<IAuthoRepo, AuthorRepo>();
            //Book store repo add here
            services.AddTransient<IBookRepo, BookRepo>();
            // logcalstorage service here
            services.AddBlazoredLocalStorage();
            //here is the Idetitny mdoe token jwt
            services.AddScoped<TokenAuthen>();
            services.AddScoped<AuthenticationStateProvider>(p =>
                p.GetRequiredService<TokenAuthen>());
            services.AddScoped<JwtSecurityTokenHandler>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapBlazorHub();
                endpoints.MapFallbackToPage("/_Host");
            });
        }
    }
}
