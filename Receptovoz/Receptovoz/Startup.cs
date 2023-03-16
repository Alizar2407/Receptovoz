using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Mvc;
using Receptovoz.Data;
using Receptovoz.Data.Repository;
using Receptovoz.Interfaces;

namespace Receptovoz
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
            services.AddDbContext<AppDBContent>(options => options.UseNpgsql(Configuration.GetConnectionString("DefaultConnection")));

            services.AddTransient<IArticleRepository, ArticleRepository>();
            services.AddTransient<IRecipeRepository, RecipeRepository>();

            services.AddRazorPages();

            services.AddMvc(mvcOtions =>
            {
                mvcOtions.EnableEndpointRouting = false;
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseDeveloperExceptionPage();
            app.UseStatusCodePages();
            app.UseStaticFiles();
            app.UseMvcWithDefaultRoute();

            IServiceScope scope = app.ApplicationServices.CreateScope();

            AppDBContent content = scope.ServiceProvider.GetRequiredService<AppDBContent>();
            DatabaseManager.SetDBContent(content);
        }
    }
}
