using Microsoft.EntityFrameworkCore;
using TextureMarket.Models;

namespace TextureMarket.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        public DbSet<Texture> Textures { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Texture>().HasData
                (
                    new Texture { Id = 1, Name = "texture1" },
                    new Texture { Id = 2, Name = "texture2" },
                    new Texture { Id = 3, Name = "texture3" },
                    new Texture { Id = 4, Name = "texture4" },
                    new Texture { Id = 5, Name = "texture5" }
                );
        }
    }
}
