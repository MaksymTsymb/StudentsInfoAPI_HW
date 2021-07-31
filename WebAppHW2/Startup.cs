using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using StudentsInfoBusinessLayer;
using StudentsInfoDataAccesLayer;
using System.Reflection;

namespace WebAppHW2
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
            services.AddScoped<IStudentsInfoService, StudentsInfoService>();
            services.AddScoped<IStudentsInfoRepository, StudentsInfoRepositoryEFCore>();
            services.AddControllers();

            var assemblies = new[]
            {
                Assembly.GetAssembly(typeof(StudentsInfoProfile))
            };

            services.AddAutoMapper(assemblies);

            services.AddDbContext<EFCoreContext>(options =>
            options.UseSqlServer(Configuration["ConnectionStrings: DefaultConnection"]));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
