
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MeuProjetoAgora.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MeuProjetoAgora.Models.Repository;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using MeuProjetoAgora.Models.business;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.AspNetCore.Diagnostics;
using System.IO;
using Microsoft.AspNetCore.Internal;
using Microsoft.AspNetCore.ResponseCompression;
using System.IO.Compression;


namespace MeuProjetoAgora
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services.AddDistributedMemoryCache();
            services.AddSession();

            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection")));

            //services.Configure<GzipCompressionProviderOptions>(options => options.Level = CompressionLevel.Optimal);
            // services.AddResponseCompression(options => { options.Providers.Add<GzipCompressionProvider>(); });

            services.AddResponseCompression(options =>
            {
                options.Providers.Add<BrotliCompressionProvider>();
                options.EnableForHttps = true;
            });

            services.AddDefaultIdentity<IdentityUser>()
               .AddRoles<IdentityRole>()
               .AddDefaultUI(UIFramework.Bootstrap3)
               .AddEntityFrameworkStores<ApplicationDbContext>();

            services.AddSignalR();

            services.Configure<IdentityOptions>(options =>
            {
                // Default Password settings.
                options.Password.RequireDigit = true;
                options.Password.RequireLowercase = true;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = true;
                options.Password.RequiredLength = 8;
                options.Password.RequiredUniqueChars = 1;
            });

            services.Configure<IdentityOptions>(options =>
            {
                // Default SignIn settings.
                options.SignIn.RequireConfirmedEmail = false;
                options.SignIn.RequireConfirmedPhoneNumber = false;
            });


            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2)
                .AddJsonOptions(opcoes => // Remove valores nulos das respostas
                {
                    opcoes.SerializerSettings.NullValueHandling =
                        Newtonsoft.Json.NullValueHandling.Ignore;
                });

            services.AddTransient<IDataService, DataService>();
            services.AddTransient<IHttpContextAccessor, HttpContextAccessor>();
            services.AddTransient<IHttpHelper, HttpHelper>();
            services.AddTransient<IRepositoryImagem, RepositoryImagem>();
            services.AddTransient<IRepositoryPedido, RepositoryPedido>();
            services.AddTransient<IRepositoryPagina, RepositoryPagina>();
            services.AddTransient<IRepositoryBackground, RepositoryBackground>();
            services.AddTransient<IRepositoryDiv, RepositoryDiv>();
            services.AddTransient<IRepositoryElemento, RepositoryElemento>();
            services.AddTransient<IRepositoryForm, RepositoryForm>();
            services.AddTransient<IRepositoryLink, RepositoryLink>();
            services.AddTransient<IRepositoryTable, RepositoryTable>();
            services.AddTransient<IRepositoryTexto, RepositoryTexto>();
            services.AddTransient<IRepositoryVideo, RepositoryVideo>();
            services.AddTransient<IRepositoryCarousel, RepositoryCarousel>();
            services.AddTransient<IUserHelper, UserHelper>();

            services.AddAuthentication()
                .AddGoogle(options =>
                {
                    options.ClientId = Configuration["ExternalLogin:Google:ClientId"];
                    options.ClientSecret = Configuration["ExternalLogin:Google:ClientSecret"];
                });

            services.Configure<ForwardedHeadersOptions>(options =>
            {
                options.ForwardedHeaders = ForwardedHeaders.XForwardedFor |
                              ForwardedHeaders.XForwardedProto;
                // Only loopback proxies are allowed by default.
                // Clear that restriction because forwarders are enabled by explicit
                // configuration.
                options.KnownNetworks.Clear();
                options.KnownProxies.Clear();
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env,
            IServiceProvider serviceProvider, IUserHelper userHelper)
        {
            if (env.IsDevelopment())
            {
                app.UseStatusCodePagesWithReExecute("/Error/{0}");
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseStatusCodePagesWithReExecute("/Error/{0}");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseAuthentication();
            app.UseCookiePolicy();
            app.UseSession();
            app.UseAuthentication();
            app.UseForwardedHeaders();

            app.UseResponseCompression();

            app.UseMvc(routes =>
            {
                
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Pedido}/{action=Index}/{id?}");
            });

            app.UseSignalR(Endpoint => Endpoint.MapHub<StreamingHub>("/streamingHub"));

            var dataService = serviceProvider.GetRequiredService<IDataService>();
            dataService.InicializaDBAsync(serviceProvider).Wait();
            CreateRoles(serviceProvider, userHelper).Wait();
        }

        private async Task CreateRoles(IServiceProvider serviceProvider, IUserHelper userHelper)
        {

            var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            var userManager = serviceProvider.GetRequiredService<UserManager<IdentityUser>>();
            string[] rolesNames =
                {
                "Admin", "SuperAdmin", "Index", "Create", "Edit", "Delete", "User", "Carousel",
                "Background", "Imagem", "Video", "Music", "Ecommerce", "Texto", "AlteraPagina",
                "Consultor", "Transacao", "Link", "Div", "Elemento", "Pagina"
            };
            IdentityResult result;
            foreach (var namesRole in rolesNames)
            {
                var roleExist = await roleManager.RoleExistsAsync(namesRole);
                if (!roleExist)
                {
                    result = await roleManager.CreateAsync(new IdentityRole(namesRole));
                }
            }
            await userHelper.CheckSuperUserAsync();
        }
    }
}
