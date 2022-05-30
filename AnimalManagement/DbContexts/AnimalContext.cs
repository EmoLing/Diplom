using Microsoft.EntityFrameworkCore;
using Model.Ads;
using Model.Ads.Animals;

namespace AnimalManagement.DbContexts
{
    public class AnimalContext : DbContext
    {
        public AnimalContext(DbContextOptions<AnimalContext> options) : base(options)
        {
            Database.EnsureCreated();

            bool isEmptyKindsOfAnimalsBase = !KindsOfAnimals.Any();
            bool isEmptyColorsOfAnimalssBase = !ColorsOfAnimals.Any();

            if (!isEmptyKindsOfAnimalsBase && !isEmptyColorsOfAnimalssBase)
                return;

            if (isEmptyKindsOfAnimalsBase)
            {
                KindsOfAnimals.AddRange(new List<KindOfAnimal>()
                {
                    new KindOfAnimal() { KindName = "Кошка"},
                    new KindOfAnimal() { KindName = "Собака"},
                    new KindOfAnimal() { KindName = "Птица"},
                });
            }

            if (isEmptyColorsOfAnimalssBase)
            {
                ColorsOfAnimals.AddRange(new List<ColorOfAnimal>()
                {
                    new ColorOfAnimal() { ColorName = "Черный"},
                    new ColorOfAnimal() { ColorName = "Белый"},
                    new ColorOfAnimal() { ColorName = "Серый"},
                    new ColorOfAnimal() { ColorName = "Рыжий"},
                    new ColorOfAnimal() { ColorName = "Бежевый"},
                    new ColorOfAnimal() { ColorName = "Коричневый"},
                    new ColorOfAnimal() { ColorName = "Многоцветный"},
                });
            }

            SaveChanges();
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
