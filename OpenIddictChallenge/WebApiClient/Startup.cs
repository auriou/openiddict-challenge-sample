using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Net.Http;
using AspNet.Security.OAuth.Introspection;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;

namespace Mvc.Client
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddAuthentication(options =>
            {
                options.DefaultScheme = OAuthIntrospectionDefaults.AuthenticationScheme;
            })

            .AddOAuthIntrospection(options =>
            {
                options.Authority = new Uri("http://localhost:44300/");
                //options.Audiences.Add("webapi1");
                options.ClientId = "webapi1";
                options.ClientSecret = "846B62D0-DEF9-4215-A99D-86E6B8DAB342";
                options.RequireHttpsMetadata = false;

                // Note: you can override the default name and role claims:
                // options.NameClaimType = "custom_name_claim";
                // options.RoleClaimType = "custom_role_claim";
            });
            //services.AddAuthentication(options =>
            //{
            //    //options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
            //    options.DefaultChallengeScheme = OpenIdConnectDefaults.AuthenticationScheme;
            //    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            //})

            ////.AddCookie(options =>
            ////{
            ////    options.LoginPath = new PathString("/signin");
            ////})

            //.AddOpenIdConnect(options =>
            //{
            //    // Note: these settings must match the application details
            //    // inserted in the database at the server level.
            //    options.ClientId = "mvc";
            //    options.ClientSecret = "901564A5-E7FE-42CB-B10D-61EF6A8F3654";

            //    options.RequireHttpsMetadata = false;
            //    options.GetClaimsFromUserInfoEndpoint = true;
            //    options.SaveTokens = true;

            //    // Use the authorization code flow.
            //    options.ResponseType = OpenIdConnectResponseType.Code;
            //    options.AuthenticationMethod = OpenIdConnectRedirectBehavior.RedirectGet;

            //    // Note: setting the Authority allows the OIDC client middleware to automatically
            //    // retrieve the identity provider's configuration and spare you from setting
            //    // the different endpoints URIs or the token validation parameters explicitly.
            //    options.Authority = "http://localhost:44300/";

            //    options.Scope.Add("email");
            //    options.Scope.Add("roles");
            //    options.Scope.Add("offline_access");

            //    options.SecurityTokenValidator = new JwtSecurityTokenHandler
            //    {
            //        // Disable the built-in JWT claims mapping feature.
            //        InboundClaimTypeMap = new Dictionary<string, string>()
            //    };

            //    options.TokenValidationParameters.NameClaimType = "name";
            //    options.TokenValidationParameters.RoleClaimType = "role";
            //});

            services.AddMvc();

            services.AddSingleton<HttpClient>();
        }

        public void Configure(IApplicationBuilder app)
        {
            app.UseDeveloperExceptionPage();

            app.UseStaticFiles();

            app.UseAuthentication();

            app.UseMvc();
        }
    }
}