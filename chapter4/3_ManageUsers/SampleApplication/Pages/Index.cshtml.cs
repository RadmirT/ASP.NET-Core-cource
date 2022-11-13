using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace SampleApplication.Pages
{
    public class IndexModel : PageModel
    {
        /// <summary>
        /// WARNING: For demo only, not thread safe, you would store these values in a database etc
        /// </summary>
        private static readonly List<string> _users = new List<string>
        {
            "Bart",
            "Jimmy",
            "Robbie"
        };

        [BindProperty, Required]
        public string NewUser{ get; set; }
        public List<string> ExistingUsers { get; set; }

        public void OnGet()
        {
            this.ExistingUsers = _users;
        }

        public IActionResult OnPost()
        {
            this.ExistingUsers = _users;
            if (!this.ModelState.IsValid)
            {
                return this.Page();
            }
            if (_users.Contains(this.NewUser))
            {
                this.ModelState.AddModelError(nameof(this.NewUser), "This user already exists!");
                return this.Page();
            }

            _users.Insert(0, this.NewUser);
            return this.RedirectToPage();
        }
    }
}
