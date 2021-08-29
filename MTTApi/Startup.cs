using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MTTApi.Entities;
using MTTApi.Services;

namespace MTTApi
{
    public class Startup
    {

        public static IConfiguration Configuration { get; private set; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }


        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
    

            //var connectionString = Startup.Configuration["connectionStrings:mttDBConnectionString"];
            //services.AddDbContext<MTTContext>(o => o.UseSqlServer(connectionString));


            services.AddDbContext<MTTContext>(
                options => options.UseSqlServer("name=ConnectionStrings:mttDBConnectionString"));

            services.AddScoped<IMTTRepository, MTTRepository>();

          

            services.AddAutoMapper(typeof(Startup));


            services.AddSingleton<IActionContextAccessor, ActionContextAccessor>();

            services.AddScoped<IUrlHelper>(implementationFactory =>
            {
                var actionContext = implementationFactory.GetService<IActionContextAccessor>()
                .ActionContext;
                return new UrlHelper(actionContext);
            });



        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }



            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Product, Models.ProductDto>();
            });


            app.UseHttpsRedirection();
            app.UseMvc();

        }
    }
}
