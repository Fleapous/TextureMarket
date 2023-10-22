using TextureMarket.Models;
using static TextureMarket.Repository.IRepository.IRepository;

namespace TextureMarket.Repository.IRepository
{
    public interface ITextureRepository : IRepository<Texture>
    {
        void update(Texture obj);
    }
}
