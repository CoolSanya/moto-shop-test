using System.ComponentModel.DataAnnotations;

namespace moto_shop_test.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        public string Description { get; set; }
        [Range(1, int.MaxValue)]
        [Required]
        public int Price { get; set; }
        public string Image { get; set; }
    }
}
