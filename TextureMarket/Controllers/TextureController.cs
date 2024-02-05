using Microsoft.AspNetCore.Mvc;
using System.Drawing.Imaging;
using System.Drawing;
using TextureMarket.Models;
using TextureMarket.Repository;
using TextureMarket.Repository.IRepository;
using Microsoft.Extensions.Hosting.Internal;
using SkiaSharp;
using SimplexNoise;

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
            if (ModelState.IsValid)
            {
                _unitOfWork.Texture.update(model);
                _unitOfWork.Save();
                return RedirectToAction("Index");    
            }

            return View(model);
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
                    // canvas.Clear(SKColors.Red);
                    // You can do more drawing operations here if needed

                    var noiseMap = GenerateNoiseMap(texture);
                    for (int x = 0; x < texture.Width; x++)
                    {
                        for (int y = 0; y < texture.Height; y++)
                        {
                            var noiseVal = (byte)noiseMap[x, y];
                            canvas.DrawPoint(x, y, new SKColor(noiseVal, noiseVal, noiseVal));        
                        }
                    }
                    
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

        private float[,] GenerateNoiseMap(Texture textureData)
        {
            SimplexNoise.Noise.Seed = textureData.Seed;
            return SimplexNoise.Noise.Calc2D(textureData.Width, textureData.Height, textureData.Scale);
        }
    }
}
