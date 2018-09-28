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
            var sqlConnectionString = Configuration.GetConnectionString("DataAccessMySqlProvider");

            services.AddDbContext<DataContext>(opt => 
                opt.UseMySql(sqlConnectionString, b => b.MigrationsAssembly("Uarung.API")));

            services.AddScoped<IDacUser, DacUser>();
            services.AddScoped<IDacProduct, DacProduct>();
            services.AddScoped<IDacProductCategory, DacProductCategory>();
            services.AddScoped<IDacDiscount, DacDiscount>();
            services.AddScoped<IDacSelectedProduct, DacSelectedProduct>();
            services.AddScoped<IDacTransaction, DacTransaction>();
            services.AddScoped<IDacDiscount, DacDiscount>();
            
            services
                .AddMvc(opt => opt.Filters.Add(new Authorize(Configuration)))
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
                app.UseDeveloperExceptionPage();
            else
                app.UseHsts();

            app.UseMvc();
        }
    }
}
