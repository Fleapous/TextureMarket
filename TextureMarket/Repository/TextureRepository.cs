using TextureMarket.Data;
using TextureMarket.Models;
using TextureMarket.Repository.IRepository;

namespace TextureMarket.Repository
{
    public class TextureRepository : Repository<Texture>, ITextureRepository
    {
        private ApplicationDbContext _db;
        public TextureRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
        {
            _db = applicationDbContext;
        }

        public void update(Texture obj)
        {
            _db.Textures.Update(obj);
        }
    }
}
