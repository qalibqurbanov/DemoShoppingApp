using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DemoShoppingApp.DataAccess.DbContext;
using DemoShoppingApp.DataAccess.UnitOfWork.Abstract;
using DemoShoppingApp.DataAccess.UnitOfWork.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DemoShoppingApp.WebUI.Extensions.Configuration
{
    public static class RegisterServices
    {
        public static void AddDefaultServices(this IServiceCollection serviceCollection, IConfiguration configuration)
        {
            serviceCollection.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("ConnectionSqlServer1")));

            serviceCollection.AddDefaultIdentity<IdentityUser>(options =>
            {
                options.SignIn.RequireConfirmedAccount = false;
            }).AddEntityFrameworkStores<ApplicationDbContext>();

            serviceCollection.AddControllersWithViews()
                             .AddRazorRuntimeCompilation();

            serviceCollection.AddRazorPages();
        }

        public static void AddCustomServices(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<IUnitOfWork, UnitOfWork>();
        }
    }
}
