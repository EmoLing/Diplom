using Microsoft.EntityFrameworkCore;
using Model.Ads;
using Model.Ads.Animals;

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
        public DbSet<Animal> Animals { get; set; }
        public DbSet<ColorOfAnimal> ColorsOfAnimals { get; set; }
        public DbSet<KindOfAnimal> KindsOfAnimals { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Ad>().HasKey(a => a.Guid);
            modelBuilder.Entity<AdCoordinates>().HasKey(a => a.Guid);
            modelBuilder.Entity<Image>().HasKey(a => a.Guid);
            modelBuilder.Entity<Animal>().HasKey(a => a.Guid);
            modelBuilder.Entity<ColorOfAnimal>().HasKey(a => a.Guid);
            modelBuilder.Entity<KindOfAnimal>().HasKey(a => a.Guid);

            modelBuilder.Entity<Ad>()
                .HasOne(a => a.Coordinates)
                .WithOne(ac => ac.Ad)
                .HasForeignKey<AdCoordinates>(ac => ac.AdGuid);

            modelBuilder.Entity<Image>()
                .HasOne(a => a.Ad)
                .WithMany(im => im.Photo);


            modelBuilder.Entity<AdCoordinates>().Property(a => a.Latitude).HasPrecision(36, 18);
            modelBuilder.Entity<AdCoordinates>().Property(a => a.Longitude).HasPrecision(36, 18);
        }
    }
}
