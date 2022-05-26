using Microsoft.EntityFrameworkCore;
using UserProfile.Model;

namespace UserProfile.DbContexts
{
    public class UserContext : DbContext
    {
        public UserContext(DbContextOptions<UserContext> options) : base(options)
        {
            if (Database.EnsureCreated())
            {
                Users.Add(new AdminUser("admin", "admin"));
                SaveChanges();
            }
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
