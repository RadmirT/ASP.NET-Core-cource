using ECommerce.ServicesLayer.Products;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ECommerce.Pages.Products
{
    public class EditProductModel : PageModel
    {
        private readonly IProductsService productsService;
        public EditProductModel(IProductsService productsService)
        {
            this.productsService = productsService;
        }

        [BindProperty]
        public ProductInputModel Input { get; set; }
        public IActionResult OnGet(int id)
        {
            var product = this.productsService.GetProduct(id);
            if (product == null)
            {
                return this.NotFound();
            }

            this.Input = new ProductInputModel() { Name = product.Name, Price = product.Price };
            return this.Page();
        }

        public IActionResult OnPost(int id)
        {
            var product = this.productsService.GetProduct(id);
            if (product == null)
            {
                return this.NotFound();
            }

            if (!ModelState.IsValid)
            {
                return this.Page();
            }
            this.productsService.UpdateProduct(id, this.Input.Name, this.Input.Price);
            return this.RedirectToPage("ProductDetail", new {id = id});
        }
    }
}
