using Microsoft.AspNetCore.Builder;
using Authorstore2.Models.Repositiories;
using BookStore2.Models;
using BookStore2.Models.Repositiories;
using Microsoft.EntityFrameworkCore;

namespace BookStore
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
            services.AddRazorPages();
            services.AddMvc(option => option.EnableEndpointRouting = false);
            services.AddScoped<IBookStoreRepository<Authors>, AuthorDbRepository>();
            services.AddScoped<IBookStoreRepository<Books>, BookDbRepository>();
            services.AddDbContext<BookStoryDbContext>(options => {
                options.UseSqlServer(Configuration.GetConnectionString("local"));
            });
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

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
            });


            app.UseMvc( route => {
                    route.MapRoute("default", "{Controller=Books}/{action=Index}/{id?}");   
                });

        }
    }
}
