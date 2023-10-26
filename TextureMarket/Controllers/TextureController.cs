using Microsoft.AspNetCore.Mvc;
using TextureMarket.Models;
using TextureMarket.Repository;
using TextureMarket.Repository.IRepository;

namespace TextureMarket.Controllers
{
    public class TextureController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public TextureController(IUnitOfWork unitOf)
        {
            _unitOfWork = unitOf;
        }
        public IActionResult Index()
        {
            IEnumerable<Texture> textureList = _unitOfWork.Texture.GetAll();
            return View(textureList);
        }

        public IActionResult Create()
        {
            return View();
        }
    }
}
