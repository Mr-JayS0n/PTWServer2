using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PTWServer1.EntityFrameworkModel;
using Microsoft.EntityFrameworkCore;



namespace PTWServer1
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRazorPages();

            services.AddDbContextPool<PTWDatabaseContext>(
                options => options.UseSqlServer(Configuration.GetConnectionString("MyConnection"))
                );

            //impose policy
            services.AddCors(options =>
            {
                options.AddPolicy("AllowAllHeaders",
                    builder =>
                    {
                        builder.AllowAnyOrigin()
                               .AllowAnyHeader()
                               .AllowAnyMethod();
                    });
            });
            services.AddSignalR(options =>
            {
                options.EnableDetailedErrors = true;
            });

            //services.AddSignalR().AddMessagePackProtocol();

            services.AddControllers();
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

            app.UseAuthorization();
            app.UseCors("AllowAllHeaders");
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
                //endpoint matching process can extract values from the request's URL and provide those values for request processing(HTTP)
                endpoints.MapHub<ClientConnector>("/toastr");
                //endpoints.MapHub<StreamHub>("/streamHub");
            });
        }
    }
}
