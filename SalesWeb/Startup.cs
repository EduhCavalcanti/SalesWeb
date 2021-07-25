using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Localization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Globalization;
using Microsoft.EntityFrameworkCore;
using SalesWeb.Data;
using SalesWeb.Services;

namespace SalesWeb {
    public class Startup {
        public Startup(IConfiguration configuration) {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services) {
            services.Configure<CookiePolicyOptions>(options => {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });


            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            //Conexão com banco de dados, configuração com aquivo => data/SalesWebContext.cs
        services.AddDbContext<SalesWebContext>(options =>
            options.UseMySql(Configuration.GetConnectionString("SalesWebContext"), builder =>
                builder.MigrationsAssembly("SalesWeb")));

            //Usado para injeção de dependência 
            //Registrando serviço para usar o Seeding Service, para popular o banco de dados
            services.AddScoped<SeedingService>();
            services.AddScoped<SellerService>();
            services.AddScoped<DepartmentService>();
            services.AddScoped<SalesRecordService>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, SeedingService seedingService) {

            //Definindo a localicação da aplicação 
            var enUs = new CultureInfo("en-US");
            var localizationOptions = new RequestLocalizationOptions
            {
                DefaultRequestCulture = new RequestCulture(enUs),
                SupportedCultures = new List<CultureInfo> { enUs },
                SupportedUICultures = new List<CultureInfo> { enUs }
            };
            app.UseRequestLocalization(localizationOptions);  

            //Se tiver no perfil de desenvolvimento vai rodar 
            if (env.IsDevelopment()) {
                app.UseDeveloperExceptionPage();
                seedingService.Seed(); //Se estiver em modo desenvolvimento vai executar o método para popular o banco de dados
            }
            else {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseMvc(routes => {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
