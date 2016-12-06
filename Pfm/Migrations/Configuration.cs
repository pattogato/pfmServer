using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Pfm.DAL;
using Pfm.Models;

namespace Pfm.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(ApplicationDbContext context)
        {
            var roleStore = new RoleStore<IdentityRole>(context);
            var roleManager = new RoleManager<IdentityRole>(roleStore);
            if (!context.Roles.Any(r => r.Name == "Admin"))
                roleManager.Create(new IdentityRole("Admin"));


            if (!(context.Users.Any(u => u.UserName == "admin@pfm.com")))
            {
                var userStore = new UserStore<ApplicationUser>(context);
                var userManager = new UserManager<ApplicationUser>(userStore);
                var userToInsert = new ApplicationUser { UserName = "admin@pfm.com", PhoneNumber = "123456789"};
                userManager.Create(userToInsert, "Password@123");
                userManager.AddToRole(userToInsert.Id, "Admin");
            }
        }
    }
}
