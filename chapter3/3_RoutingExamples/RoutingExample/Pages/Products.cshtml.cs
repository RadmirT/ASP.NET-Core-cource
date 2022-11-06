using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RoutingExample.Pages
{
    public class ProductsModel : PageModel
    {
        public ProductsModel()
        {
        }

        public string Category { get; set; }

        public string Name { get; set; }

        public int Id { get; set; }
        public IActionResult OnGet(string category, string name, int id)
        {
            Category = category;
            Name = name;
            Id = id;
            return Page();
        }

    }
}