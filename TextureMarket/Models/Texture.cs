using System.ComponentModel.DataAnnotations;

namespace TextureMarket.Models
{
    public class Texture
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }

        public int Width { get; set; }
        public int Height { get; set; }
        public NoiseType NoiseType { get; set; }
        public int Seed { get; set; }
        public float Scale { get; set; }
        public int Octaves { get; set; }
        public float Persistence { get; set; }
        public float Lacunarity { get; set; }
    }
    public enum NoiseType
    {
        Perlin,
        Simplex,
    }
}
