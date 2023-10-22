using TextureMarket.Data;
using TextureMarket.Repository.IRepository;

namespace TextureMarket.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private ApplicationDbContext _db;
        public ITextureRepository Texture { get; private set; }

        public UnitOfWork(ApplicationDbContext applicationDb)
        {
            _db = applicationDb;
            Texture = new TextureRepository(_db);
        }
        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
