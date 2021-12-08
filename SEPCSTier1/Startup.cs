using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Blazored.Toast;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SEPCSTier1.Data;
using SEPCSTier1.Models;

namespace SEPCSTier1
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
            services.AddScoped<IUserData, UserJSONData>();
            services.AddScoped<IItemData, ItemJSONData>();
            services.AddScoped<IOfferData, OfferData>();
            services.AddScoped<IWalletData, WalletData>();
            services.AddScoped<IPaymentData, PaymentData>();
            services.AddScoped<IOrderData, OrderData>();
            services.AddScoped<ICart, Cart>();
            services.AddScoped<IShoppingCartData, ShoppingCartData>();
            services.AddScoped<IWalletData, WalletData>();
            services.AddScoped<AuthenticationStateProvider, CustomAuthenticationStateProvider>();
            services.AddBlazoredToast();
            services
                .AddGraphqlClient()
                .ConfigureHttpClient(client => client.BaseAddress = new Uri("https://localhost:5001/graphql/"));


            services.AddAuthorization(options =>
            {
                options.AddPolicy("SecurityLevel4", a => a.RequireAuthenticatedUser().RequireClaim("level", "4"));

                options.AddPolicy("SecurityLevel2", a => a.RequireAuthenticatedUser().RequireAssertion(context =>
                {
                    Claim levelClaim = context.User.FindFirst(claim => claim.Type.Equals("Level"));
                    if (levelClaim == null) return false;
                    return int.Parse(levelClaim.Value) >= 2;

                }));
            });
        }
        
        private void SecurityLevel4(AuthorizationPolicyBuilder a)
        {
            a.RequireAuthenticatedUser().RequireClaim("SecurityLevel4", "4");
        }
        
        //TESTY
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