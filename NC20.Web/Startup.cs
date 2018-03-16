using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NC20.Entities;
using NC20.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.SpaServices.Webpack;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace NC20.Web
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
            services.Configure<ConfigurationHelper>(Configuration);
            services.AddDbContext<NC20Entities>(options => options.UseSqlServer(Configuration.GetConnectionString("CBDBConnection"), b => b.MigrationsAssembly("NC20.Web")));
            services.AddScoped<NC20Entities>();
            services.AddScoped<NC20DBUnitOfWork>();
            services.AddScoped<NC20DBRepository>();
            services.AddScoped<IBaseUnitOfWork<NC20Entities>, NC20DBUnitOfWork>();
            RegisterServiceHelper.RegisterRepository(services);
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseBrowserLink();
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
