using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;
using Pfm.Models;
using Pfm.Models.Do;

namespace Pfm.DAL
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Category> Categories { get; set; }

        public DbSet<Transaction> Transactions { get; set; }

        public DbSet<Tag> Tags { get; set; } 
        
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}