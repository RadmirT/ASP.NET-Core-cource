using ECommerce.ServicesLayer.Products;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ECommerce.Pages.Products
{
    public class IndexModel : PageModel
    {
        private readonly IProductsService productsService;
        public IndexModel(IProductsService productsService)
        {
            this.productsService = productsService;

        }
        public IEnumerable<ProductViewModel> Products { get; set; }

        public void OnGet()
        {
            Products = this.productsService.GetProducts();
        }
    }
}
