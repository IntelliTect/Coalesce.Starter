using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;
using Coalesce.Starter.Data;
using Microsoft.EntityFrameworkCore;
using IntelliTect.Coalesce.TypeDefinition;
using Newtonsoft.Json.Serialization;
using Newtonsoft.Json;
using System.Security.Claims;
using IntelliTect.Coalesce.DataAnnotations;

namespace Coalesce.Starter.Web
{
    public class Startup
    {
        public IConfigurationRoot Configuration { get; set; }

        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true, reloadOnChange: true);

            builder.AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit http://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            // Add Entity Framework services to the services container.
            services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddMvc().AddJsonOptions(options =>
            {
                options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;

                var resolver = options.SerializerSettings.ContractResolver;
                if (resolver != null) (resolver as DefaultContractResolver).NamingStrategy = null;

                options.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();

                options.SerializerSettings.NullValueHandling = NullValueHandling.Ignore;
            });

            services.AddAuthentication(DemoMiddleware.AuthenticationScheme)
                .AddCookie(DemoMiddleware.AuthenticationScheme, options => {
                    options.AccessDeniedPath = "/Account/AccessDenied/";
                    options.LoginPath = "/Account/Login";
                    options.LogoutPath = "/Account/LogOff";
                });

            ReflectionRepository.AddContext<AppDbContext>();

            RoleMapping.Add("Admin", "S-1-5-4");  // Interactive user.
            RoleMapping.Add("User", "S-1-1-0");  // Everyone who has logged on.
        }

            // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
            public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            //loggerFactory.MinimumLevel = LogLevel.Information;
            loggerFactory.AddConsole();
            loggerFactory.AddDebug();

            // Add the platform handler to the request pipeline.
            app.UseStaticFiles();

            app.UseDeveloperExceptionPage();

            // *** DEMO ONLY ***
            app.UseAuthentication();
            app.UseMiddleware<DemoMiddleware>();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "Area Route",
                    template: "{area:exists}/{controller}/{action}/{id?}",
                    defaults: new { controller = "Home", action = "Index" });
                routes.MapRoute(
                    name: "Default Route",
                    template: "{controller}/{action}/{id?}",
                    defaults: new { controller = "Home", action = "Index" });
            });

            var classNameParts = GetType().FullName.Split(new char[] { '.' });
            var ns = string.Join(".", classNameParts.Take(classNameParts.Length - 1));
            //foreach (var model in ReflectionRepository.Models.Where(m => m.PrimaryKey != null && m.OnContext))
            //{
            //    Mapper.AddMap(model.Type, Type.GetType($"{ns}.Models.{model.Type.Name}DtoGen"));
            //}
        }
    }
}
