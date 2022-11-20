using System.ComponentModel.DataAnnotations;

namespace ECommerce.Pages.Products
{
    public class ProductInputModel
    {
        [Required]
        [MinLength(4)]
        public string Name { get; set; }

        [Range(0, int.MaxValue)]
        public decimal Price { get; set; }
    }
}
