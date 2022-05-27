using Ads.Models;
using Microsoft.EntityFrameworkCore;

namespace Ads.DbContexts
{
    public class AdContext : DbContext
    {
        public AdContext(DbContextOptions<AdContext> options) : base(options) 
        {
            Database.EnsureCreated();
        }

        public DbSet<Ad> Ads { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<AdCoordinates> AdCoordinates { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Ad>().HasKey(a => a.Guid);
            modelBuilder.Entity<Image>().HasKey(a => a.Guid);
            modelBuilder.Entity<AdCoordinates>().HasKey(c => c.Guid);
        }
    }
}
