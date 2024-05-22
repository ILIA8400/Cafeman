using CafeMan_Project.Filters;
using CafeMan_Project.Infra;
using CafeMan_Project.Models.Dal;
using CafeMan_Project.Models.Entities;
using CafeMan_Project.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;

namespace CafeMan_Project
{
    public static class HostingExtensions
    {
        public static WebApplication ConfigureServices(this WebApplicationBuilder builder)
        {
            //builder.Services.AddHsts(opt =>
            //{
            //    opt.MaxAge = TimeSpan.FromDays(10);
            //    opt.IncludeSubDomains = true;
            //    opt.Preload = true;
            //});


            builder.Services.AddIdentity<User, IdentityRole>(c =>
            {
                c.Password.RequiredLength = 8;
                c.Password.RequireDigit = false;
                c.Password.RequireUppercase = false;
                c.Password.RequireNonAlphanumeric = false;
                c.Password.RequireLowercase = true;


            }).AddEntityFrameworkStores<CafemanDbContext>().AddErrorDescriber<CustomIdentityErrorDescriber>();

            builder.Services.AddAuthorization(c =>
            {
                c.AddPolicy("Roles", po =>
                {
                    po.RequireRole("User", "Cafe owner", "Admin");
                });

            });



            builder.Configuration.AddUserSecrets("f99bedd6-294d-4d7c-9cdc-160674c037ff");

            //var connection = builder.Configuration.GetConnectionString("cnn");
            var connection = builder.Configuration["ConnectionStrings:cnn"];
            builder.Services.AddDbContext<CafemanDbContext>(p => p.UseSqlServer(connection));
            builder.Services.AddControllersWithViews().AddMvcOptions(opt =>
            {
                opt.Filters.Add<MyHttpsAttribute>();
                
            });

            builder.Configuration.SetBasePath(builder.Environment.ContentRootPath).AddJsonFile("appsettings.ilia.json");

            builder.Logging.AddFile();


            


            builder.Services.AddScoped<IUserRepository<User>,UserRepo>();
            builder.Services.AddScoped<ICafeRepository<Cafe>,CafeRepo>();
            builder.Services.AddScoped<IRepository<Edibles>, EdibleRepo>();
            builder.Services.AddScoped<IRepository<Comment>, CommentRepo>();

            

            return builder.Build();
        }

        public static WebApplication ConfigurePipeline(this WebApplication app)
        {
            //if (!app.Environment.IsDevelopment())
            //{
            //    app.UseHttpsRedirection();
            //    app.UseHsts();
            //}
 
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseStaticFiles();

            app.MapControllerRoute("Default","{Controller=Home}/{Action=Index}/{Id?}");

            return app;
        }
    }
}
