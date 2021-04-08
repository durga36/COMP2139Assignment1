using ASPAssignment1.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ASPAssignment1
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
            services.AddMemoryCache();
            services.AddSession();

            services.AddRouting(options => {
                options.LowercaseUrls = true;
                options.AppendTrailingSlash = true;
            });
            services.AddControllersWithViews();

            services.AddDbContext<ProductContext>(options =>
                  options.UseSqlServer(Configuration.GetConnectionString("ProductContext")));

            services.AddDbContext<TechnicianContext>(options =>
                  options.UseSqlServer(Configuration.GetConnectionString("TechnicianContext")));

            services.AddDbContext<CustomerContext>(options =>
                  options.UseSqlServer(Configuration.GetConnectionString("CustomerContext")));

            services.AddDbContext<IncidentContext>(options =>
                  options.UseSqlServer(Configuration.GetConnectionString("IncidentContext")));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseDeveloperExceptionPage();
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseSession();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapControllerRoute(
                    name: "about",
                    pattern: "{controller=Home}/{action=About}/{id?}/{slug?}");

                endpoints.MapControllerRoute(
                    name: "products",
                    pattern: "{controller=Product}/{action=List}/products/{products}/{slug?}");

                endpoints.MapControllerRoute(
                    name: "technicians",
                    pattern: "{controller=Technician}/{action=List}/technicians/{technicians}/{slug?}");

                endpoints.MapControllerRoute(
                    name: "customers",
                    pattern: "{controller=Customer}/{action=List}/customers/{customers}/{slug?}");

                endpoints.MapControllerRoute(
                    name: "incidents",
                    pattern: "{controller=Incident}/{action=List}/incidents/{incidents}/{slug?}");

                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}/{slug?}");
            });
        }
    }
}
