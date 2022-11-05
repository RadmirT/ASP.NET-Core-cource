using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PageHandlers.ServicesLayer.Search;

namespace PageHandlers.Pages
{
    public class SearchModel : PageModel
    {
        private readonly ISearchService searchService;
        public SearchModel(ISearchService searchService)
        {
            this.searchService = searchService;
        }

        [BindProperty]
        public BindingModel Input { get; set; }
        public List<Product> Results { get; set; }

        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            if (this.ModelState.IsValid)
            {
                this.Results = this.searchService.SearchProducts(this.Input.SearchTerm);
                return this.Page();
            }
            return this.RedirectToPage();
        }

        public class BindingModel
        {
            [Required]
            public string SearchTerm { get; set; }
        }
    }
}