using Microsoft.EntityFrameworkCore;
using UserProfile.Model;

namespace UserProfile.DbContexts
{
    public class UserContext : DbContext
    {
        public UserContext(DbContextOptions<UserContext> options) : base(options)
        {
            Database.EnsureCreated();

            if (Users.Any(u => u.Login == "admin" && u.Password == "admin"))
                return;

            Users.Add(new AdminUser("admin", "admin"));
            SaveChanges();

        }

        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasKey(a => a.Guid);
            modelBuilder.Entity<AdminUser>();
            modelBuilder.Entity<SimpleUser>();
        }
    }
}
