using System;
using ex78Core_Blazor_Shopping.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

[assembly: HostingStartup(typeof(ex78Core_Blazor_Shopping.Areas.Identity.IdentityHostingStartup))]
namespace ex78Core_Blazor_Shopping.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<ex78Core_Blazor_ShoppingContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("ex78Core_Blazor_ShoppingContextConnection")));

                services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
                    .AddEntityFrameworkStores<ex78Core_Blazor_ShoppingContext>();
            });
        }
    }
}