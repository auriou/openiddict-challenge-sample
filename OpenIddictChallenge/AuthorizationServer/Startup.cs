using AspNet.Security.OpenIdConnect.Primitives;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SRPIntranet.Security.Identity.Models;
using SRPIntranet.Security;
using SRPIntranet.Security.Identity;
using System.Threading.Tasks;
using System;
using OpenIddict.Core;
using OpenIddict.EntityFrameworkCore.Models;
using OpenIddict.Abstractions;
using Microsoft.AspNetCore.DataProtection;

namespace AuthorizationServer
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors();
            services.AddMvc();

            services.AddDbContext<ApplicationDbContext>(options =>
            {
                // Configure the context to use Microsoft SQL Server.
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));

                // Register the entity sets needed by OpenIddict.
                // Note: use the generic overload if you need
                // to replace the default OpenIddict entities.
                options.UseOpenIddict();
            });

            // Register the Identity services.
            services.AddIdentity<ApplicationUser, ApplicationRole>()
                .AddDefaultTokenProviders();


            services.AddTransient<IUserStore<ApplicationUser>, FakeUserStore>();
            services.AddTransient<IRoleStore<ApplicationRole>, FakeRoleStore>();
            services.AddTransient<IPasswordHasher<ApplicationUser>, FakePasswordHasher>();
            /*
            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();
                */

            // Configure Identity to use the same JWT claims as OpenIddict instead
            // of the legacy WS-Federation claims it uses by default (ClaimTypes),
            // which saves you from doing the mapping in your authorization controller.
            services.Configure<IdentityOptions>(options =>
            {
                options.ClaimsIdentity.UserNameClaimType = OpenIdConnectConstants.Claims.Name;
                options.ClaimsIdentity.UserIdClaimType = OpenIdConnectConstants.Claims.Subject;
                options.ClaimsIdentity.RoleClaimType = OpenIdConnectConstants.Claims.Role;
            });

            services.AddDataProtection()
                .PersistKeysToFileSystem(new System.IO.DirectoryInfo(@"C:\0-Temp\dataProtection"))
                .SetApplicationName("MyAPP");

            services.AddOpenIddict()

                // Register the OpenIddict core services.
                .AddCore(options =>
                {
                    // Register the Entity Framework stores and models.
                    options.UseEntityFrameworkCore()
                           .UseDbContext<ApplicationDbContext>();
                })

                // Register the OpenIddict server handler.
                .AddServer(options =>
                {
                    // Register the ASP.NET Core MVC binder used by OpenIddict.
                    // Note: if you don't call this method, you won't be able to
                    // bind OpenIdConnectRequest or OpenIdConnectResponse parameters.
                    options.UseMvc();

                    // Enable the token endpoint.
                    options.EnableTokenEndpoint("/connect/token");

                    // Enable the password and the refresh token flows.
                    options
                    //.AllowAuthorizationCodeFlow()
                    .AllowPasswordFlow()
                           .AllowRefreshTokenFlow();

                    options.RegisterScopes(OpenIddictConstants.Scopes.Email,
                                           OpenIddictConstants.Scopes.Profile,
                                           OpenIddictConstants.Scopes.Roles);

                    // Accept anonymous clients (i.e clients that don't send a client_id).
                    options.AcceptAnonymousClients();

                    // During development, you can disable the HTTPS requirement.
                    options.DisableHttpsRequirement();

                    // Note: to use JWT access tokens instead of the default
                    // encrypted format, the following lines are required:
                    //
                    // options.UseJsonWebTokens();
                    // options.AddEphemeralSigningKey();
                })

                // Register the OpenIddict validation handler.
                // Note: the OpenIddict validation handler is only compatible with the
                // default token format or with reference tokens and cannot be used with
                // JWT tokens. For JWT tokens, use the Microsoft JWT bearer handler.
                .AddValidation();

            // If you prefer using JWT, don't forget to disable the automatic
            // JWT -> WS-Federation claims mapping used by the JWT middleware:
            //
            // JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Clear();
            // JwtSecurityTokenHandler.DefaultOutboundClaimTypeMap.Clear();
            //
            // services.AddAuthentication()
            //     .AddJwtBearer(options =>
            //     {
            //         options.Authority = "http://localhost:54895/";
            //         options.Audience = "resource_server";
            //         options.RequireHttpsMetadata = false;
            //         options.TokenValidationParameters = new TokenValidationParameters
            //         {
            //             NameClaimType = OpenIdConnectConstants.Claims.Subject,
            //             RoleClaimType = OpenIdConnectConstants.Claims.Role
            //         };
            //     });

            // Alternatively, you can also use the introspection middleware.
            // Using it is recommended if your resource server is in a
            // different application/separated from the authorization server.
            //
            // services.AddAuthentication()
            //     .AddOAuthIntrospection(options =>
            //     {
            //         options.Authority = new Uri("http://localhost:54895/");
            //         options.Audiences.Add("resource_server");
            //         options.ClientId = "resource_server";
            //         options.ClientSecret = "875sqd4s5d748z78z7ds1ff8zz8814ff88ed8ea4z4zzd";
            //         options.RequireHttpsMetadata = false;
            //     });
        }

        public void Configure(IApplicationBuilder app)
        {
            app.UseDeveloperExceptionPage();

            app.UseCors(builder =>
            {
                builder.AllowAnyOrigin();
                builder.AllowAnyHeader();
                builder.AllowAnyMethod();
            });

            app.UseAuthentication();

            app.UseMvcWithDefaultRoute();
            InitializeAsync(app.ApplicationServices).GetAwaiter().GetResult();
        }

        private async Task InitializeAsync(IServiceProvider services)
        {
            // Create a new service scope to ensure the database context is correctly disposed when this methods returns.
            using (var scope = services.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
                await context.Database.EnsureCreatedAsync();

                var manager = scope.ServiceProvider.GetRequiredService<OpenIddictApplicationManager<OpenIddictApplication>>();

                if (await manager.FindByClientIdAsync("webtest") == null)
                {
                    var descriptor = new OpenIddictApplicationDescriptor
                    {
                        ClientId = "webtest",
                        DisplayName = "webtest client application",
                        Permissions =
                            {
                                OpenIddictConstants.Permissions.Endpoints.Token,
                                OpenIddictConstants.Permissions.GrantTypes.Password,
                                OpenIddictConstants.Permissions.GrantTypes.RefreshToken,
                                OpenIddictConstants.Permissions.Scopes.Email,
                                OpenIddictConstants.Permissions.Scopes.Profile,
                                OpenIddictConstants.Permissions.Scopes.Roles
                        }
                    };

                    await manager.CreateAsync(descriptor);
                }

                if (await manager.FindByClientIdAsync("webapi1") == null)
                {
                    var descriptor = new OpenIddictApplicationDescriptor
                    {
                        ClientId = "webapi1",
                        ClientSecret = "846B62D0-DEF9-4215-A99D-86E6B8DAB342",
                        Permissions =
                            {
                                OpenIddictConstants.Permissions.Endpoints.Introspection
                            }
                    };

                    await manager.CreateAsync(descriptor);
                }

                //if (await manager.FindByClientIdAsync("mvc") == null)
                //{
                //    var descriptor = new OpenIddictApplicationDescriptor
                //    {
                //        ClientId = "mvc",
                //        ClientSecret = "901564A5-E7FE-42CB-B10D-61EF6A8F3654",
                //        DisplayName = "MVC client application",
                //        PostLogoutRedirectUris = { new Uri("http://localhost:44301/signout-callback-oidc") },
                //        RedirectUris = { new Uri("http://localhost:44301/signin-oidc") },
                //        Permissions =
                //        {
                //            OpenIddictConstants.Permissions.Endpoints.Authorization,
                //            OpenIddictConstants.Permissions.Endpoints.Logout,
                //            OpenIddictConstants.Permissions.Endpoints.Token,
                //            OpenIddictConstants.Permissions.GrantTypes.AuthorizationCode,
                //            OpenIddictConstants.Permissions.GrantTypes.RefreshToken,
                //            OpenIddictConstants.Permissions.Scopes.Email,
                //            OpenIddictConstants.Permissions.Scopes.Profile,
                //            OpenIddictConstants.Permissions.Scopes.Roles
                //        }
                //    };

                //    await manager.CreateAsync(descriptor);
                //}




            }
        }
    }
}
