using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WebApi.BusinessLayer.Classes;
using WebApi.BusinessLayer.Interfaces;
using WebApi.BusinessLayer.Models;
using WebApi.DataAccessLayer;
using WebApi.DataAccessLayer.Entities;

namespace WebApi
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
            services.AddCors();
            services.AddAutoMapper(typeof(Startup));
            services.AddDbContext<GroupManagementDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("GroupManagementDbContext"), migrations => migrations.MigrationsAssembly("WebApi")));
            services.AddScoped<IGroupService, GroupService>();
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        [System.Obsolete]
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }
            app.UseCors(options => options.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
            Mapper.Initialize(config =>
            {
                config.CreateMap<GroupEntity, Group>();
            });
            //using (var scope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
            //{
            //    scope.ServiceProvider.GetService<GroupManagementDbContext>().Database.Migrate();
            //}
            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
