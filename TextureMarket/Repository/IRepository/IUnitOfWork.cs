namespace TextureMarket.Repository.IRepository
{
    public interface IUnitOfWork
    {
        public ITextureRepository Texture { get; }
        void Save();
    }
}
