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
    }
}
