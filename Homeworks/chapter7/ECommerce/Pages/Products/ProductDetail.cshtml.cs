using ECommerce.ServicesLayer.Products;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ECommerce.Pages.Products
{
    public class ProductDetailModel : PageModel
    {
        private readonly IProductsService productsService;

        public ProductDetailModel(IProductsService productsService)
        {
            this.productsService = productsService;
        }
        public IActionResult OnGet(int id)
        {
            var product = this.productsService.GetProduct(id);
            if (product == null)
            {
                return this.NotFound();
            }

            this.Product = product;
            return this.Page();
        }

        public Product Product { get; set; }
    }
}
