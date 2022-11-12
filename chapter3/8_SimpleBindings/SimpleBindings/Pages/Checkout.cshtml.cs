using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace SimpleBindings.Pages
{
    [IgnoreAntiforgeryToken]
    public class CheckoutModel : PageModel
    {
        //public IActionResult OnPost(string firstName, string lastName, string phoneNumber, string email)
        public IActionResult OnPost(UserBindingModel user)
        {
            return this.Page();
        }

        public IActionResult OnGet()
        {
            return this.Page();
        }
        
        [BindProperty]
        public UserBindingModel User { get; set; }  

    }

    public class UserBindingModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
    } 

}
