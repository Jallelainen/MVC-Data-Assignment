using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MVC_Data_Assignment.Models.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_Data_Assignment.Models.Database
{
    public class SeedDataBase
    {
        public static IHost CreateDataBaseIfNotExists(IHost host)
        {
            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                try
                {
                    var context = services.GetRequiredService<IdentityPersonDbContext>();// get access to database
                    context.Database.Migrate();

                    if ( ! context.Roles.Any()) // are there any roles? no = new database
                    {
                        var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();

                        roleManager.CreateAsync(new IdentityRole("Imperator")).Wait();
                        roleManager.CreateAsync(new IdentityRole("Subject")).Wait();

                        var userManager = services.GetRequiredService<UserManager<AppUser>>();

                        AppUser deus = new AppUser() { UserName = "Deus" };

                        userManager.CreateAsync(deus, "Qwerty!23456").Wait();

                        deus = userManager.FindByNameAsync("Deus").Result;

                        userManager.AddToRoleAsync(deus, "Imperator").Wait();
                    }
                }
                catch (Exception e)
                {
                    throw;
                }

                return host;
            }
        }
    }
}
