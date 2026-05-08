using Microsoft.EntityFrameworkCore;
using PawsitivePlace.Model.Entities;

namespace PawsitivePlace.Model
{
    public class AppDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public string DbPath { get; }

        public AppDbContext()
        {
            var dataDir = FileSystem.AppDataDirectory;
            DbPath = Path.Combine(dataDir, "pawsitiveplace.db");
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite($"Data Source={DbPath}");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Seed initial users
            modelBuilder.Entity<User>().HasData(
                new User { Id = 1, Username = "Shetty", Password = "123", CreatedAt = DateTime.UtcNow },
                new User { Id = 2, Username = "Man", Password = "456", CreatedAt = DateTime.UtcNow },
                new User { Id = 3, Username = "Another", Password = "789", CreatedAt = DateTime.UtcNow }
            );
        }
    }
}
