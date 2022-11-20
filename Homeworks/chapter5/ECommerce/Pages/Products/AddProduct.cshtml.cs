using System.ComponentModel.DataAnnotations;
using ECommerce.ServicesLayer.Products;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ECommerce.Pages.Products
{
    public class AddProductModel : PageModel
    {
        [BindProperty]
        public ProductInputModel Input { get; set; } 
        public void OnGet()
        {
        }
    }
}
