namespace TextureMarket.Repository.IRepository
{
    public interface IRepository
    {
        public interface IRepository<T> where T : class
        {
            IEnumerable<T> GetAll();
            T GetById(int id);
            void Update(T entity);
            void Delete(T entity);
        }
    }
}
