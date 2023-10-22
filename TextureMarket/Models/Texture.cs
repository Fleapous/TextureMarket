using System.ComponentModel.DataAnnotations;

namespace TextureMarket.Models
{
    public class Texture
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
    }
}
