using Lab4.Data;
using Microsoft.EntityFrameworkCore;

namespace Lab4
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            /* Define services here */
            var connection = Configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<MarketDbContext>(options => options.UseSqlServer(connection));
            services.AddControllersWithViews();


        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();
            app.UseRouting();
            
            /* Define routing here */
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                 pattern: "{controller=Home}/{action=Index}/{id?}");
            });
            

        }
    }
}