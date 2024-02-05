using Microsoft.AspNetCore.Mvc;
using System.Drawing.Imaging;
using System.Drawing;
using TextureMarket.Models;
using TextureMarket.Repository;
using TextureMarket.Repository.IRepository;
using Microsoft.Extensions.Hosting.Internal;
using SkiaSharp;

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

            string wwwrootPath = hostingEnvironment.WebRootPath;
            string filePath = Path.Combine(wwwrootPath, "images", "generatedTexture.png");
            System.IO.File.WriteAllBytes(filePath, textureData);

            return Json(new { filePath = "/images/generatedTexture.png" });
        }

        private byte[] GenerateTextureData(Texture texture)
        {


            using (var skBitmap = new SKBitmap(texture.Width, texture.Height))
            {
                // Use SkiaSharp to draw on the SKBitmap
                using (var canvas = new SKCanvas(skBitmap))
                {
                    canvas.Clear(SKColors.Red);
                    // You can do more drawing operations here if needed
                }

                // Convert SKBitmap to byte array
                using (var image = SKImage.FromBitmap(skBitmap))
                using (var stream = new MemoryStream())
                {
                    image.Encode(SKEncodedImageFormat.Png, 100).SaveTo(stream);
                    return stream.ToArray();
                }
            }
        }
    }
}
