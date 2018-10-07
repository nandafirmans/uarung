using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Uarung.API.Utility;
using Uarung.Data.Contract;
using Uarung.Data.DataAccess;
using Uarung.Data.Provider;
using Uarung.Model;

namespace Uarung.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        private IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            var redisOption = Configuration.GetValue<string>(Constant.ConfigKey.RedisOption);
            var sqlConnectionString = Configuration.GetConnectionString("DataAccessPostgreSqlProvider");

            services.AddDistributedRedisCache(opt => opt.Configuration = redisOption);
            services.AddDbContext<DataContext>(opt =>
                opt.UseNpgsql(sqlConnectionString, b => b.MigrationsAssembly("Uarung.API")));

            services.AddScoped<IDacUser, DacUser>();
            services.AddScoped<IDacProduct, DacProduct>();
            services.AddScoped<IDacProductCategory, DacProductCategory>();
            services.AddScoped<IDacProductImage, DacProductImage>();
            services.AddScoped<IDacDiscount, DacDiscount>();
            services.AddScoped<IDacSelectedProduct, DacSelectedProduct>();
            services.AddScoped<IDacTransaction, DacTransaction>();
            services.AddScoped<IDacDiscount, DacDiscount>();

            services
                .AddMvc(opt => opt.Filters.Add(typeof(Authorize)))
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
                app.UseDeveloperExceptionPage();
            else
                app.UseHsts();

            app.UseMvc();
            app.UseStaticFiles();
        }
    }
}
