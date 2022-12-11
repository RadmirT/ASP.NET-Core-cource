using System.ComponentModel.DataAnnotations;
using ECommerce.Filters;
using ECommerce.ServicesLayer.Products;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ECommerce.Pages.Products
{
    [PageValidateModel]
    public class AddProductModel : PageModel
    {
        private readonly IProductsService productsService;

        [BindProperty]
        public ProductInputModel Input { get; set; }

        public AddProductModel(IProductsService productsService)
        {
            this.productsService = productsService ?? throw new ArgumentNullException(nameof(productsService));
        }
        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            this.productsService.AddProduct(this.Input.Name, this.Input.Price);
            return this.RedirectToPage("Index");
        }
    }
}
