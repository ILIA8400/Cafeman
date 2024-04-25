using CafeMan_Project.Models.Dal;
using CafeMan_Project.Models.Entities;
using CafeMan_Project.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;

namespace CafeMan_Project
{
    public static class HostingExtensions
    {
        public static WebApplication ConfigureServices(this WebApplicationBuilder builder)
        {

            var connection = builder.Configuration.GetConnectionString("cnn");
            builder.Services.AddDbContext<CafemanDbContext>(p => p.UseSqlServer(connection));
            builder.Services.AddControllersWithViews();

            builder.Services.AddScoped<IRepository<Cafe>,CafeRepo>();
            builder.Services.AddScoped<IRepository<User>, UserRepo>();
            builder.Services.AddScoped<IRepository<Menu>, MenuRepo>();
            builder.Services.AddScoped<IRepository<Edibles>, EdibleRepo>();
            builder.Services.AddScoped<IRepository<Comment>, CommentRepo>();

            return builder.Build();
        }

        public static WebApplication ConfigurePipeline(this WebApplication app)
        {

            app.UseStaticFiles();

            app.MapControllerRoute("Default", "{Controller=Home}/{Action=Index}/{Id?}");

            return app;
        }
    }
}
