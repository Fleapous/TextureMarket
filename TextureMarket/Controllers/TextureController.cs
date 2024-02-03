using Microsoft.AspNetCore.Mvc;
using System.Drawing.Imaging;
using System.Drawing;
using TextureMarket.Models;
using TextureMarket.Repository;
using TextureMarket.Repository.IRepository;
using Microsoft.Extensions.Hosting.Internal;

namespace TextureMarket.Controllers
{
    public class TextureController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment hostingEnvironment;
        public TextureController(IUnitOfWork unitOf, IWebHostEnvironment hostEnvironment)
        {
            _unitOfWork = unitOf;
            this.hostingEnvironment = hostEnvironment;
        }
        public IActionResult Index()
        {
            IEnumerable<Texture> textureList = _unitOfWork.Texture.GetAll();
            return View(textureList);
        }

        [HttpGet]
        public IActionResult Create()
        {

            return View(new Texture());
        }

        [HttpPost]
        public IActionResult Create(Texture model)
        {
            
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Generate([FromBody] Texture texture)
        {
            Console.WriteLine($"Received Width: {texture.Width}, Height: {texture.Height}, NoiseType: {texture.NoiseType}");
            byte[] textureData = GenerateTextureData(texture);

            // Save the texture file
            string wwwrootPath = hostingEnvironment.WebRootPath;
            string filePath = Path.Combine(wwwrootPath, "images", "generatedTexture.png");
            System.IO.File.WriteAllBytes(filePath, textureData);

            // Return the file path or content
            return Json(new { filePath = "/images/generatedTexture.png" });
        }

        private byte[] GenerateTextureData(Texture texture)
        {


            using (var bitmap = new Bitmap(texture.Width, texture.Height))
            {
                using (var graphics = Graphics.FromImage(bitmap))
                {
                    graphics.Clear(Color.Red);
                }

                using (MemoryStream stream = new MemoryStream())
                {
                    bitmap.Save(stream, ImageFormat.Png);
                    return stream.ToArray();
                }
            }
        }
    }
}
