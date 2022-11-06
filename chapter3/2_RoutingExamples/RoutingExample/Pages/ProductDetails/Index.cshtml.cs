using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RoutingExample.ServicesLayer.Products;

namespace RoutingExample.Pages.ProductDetails
{
    public class IndexModel : PageModel
    {
        private readonly ProductService service;
        public IndexModel(ProductService service)
        {
            this.service = service;
        }

        public Product Selected { get; set; }

        public IActionResult OnGet(string name)
        {
            Selected = this.service.GetProduct(name);
            if (Selected is null)
            {
                return NotFound();
            }
            return Page();
        }

    }
}