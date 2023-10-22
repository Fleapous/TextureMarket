using Microsoft.EntityFrameworkCore;
using static TextureMarket.Repository.IRepository.IRepository;
using TextureMarket.Data;

namespace TextureMarket.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly ApplicationDbContext _db;
        internal DbSet<T> dbSet;
        public Repository(ApplicationDbContext applicationDbContext)
        {
            _db = applicationDbContext;
            this.dbSet = _db.Set<T>();
        }
        public void Delete(T entity)
        {
            dbSet.Remove(entity);
        }

        public IEnumerable<T> GetAll()
        {
            return dbSet.ToList();
        }

        public T GetById(int id)
        {
            return dbSet.Find(id);
        }

        public void Update(T entity)
        {
            dbSet.Update(entity);
        }
    }
}
