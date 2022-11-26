using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ZooWebsite.Models;

namespace ZooWebsite.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<habitats> habitats { get; set; }

        public DbSet<employees> employees { get; set; }

        public DbSet<animals> animals { get; set; }

    }
}