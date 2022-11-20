using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ECommerce.Pages.Products
{
    public class AddProductModel : PageModel
    {
        [BindProperty(SupportsGet = true)]
        public InputModel Input { get; set; } 
        public void OnGet()
        {
        }
    }

    public class InputModel
    {
        [Required]
        [MinLength(4)]
        public string Name { get; set; }

        [Range(0, int.MaxValue)]    
        public string Price { get; set; }
    }
}
