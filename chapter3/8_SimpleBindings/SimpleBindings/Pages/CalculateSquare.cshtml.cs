using Microsoft.AspNetCore.Mvc.RazorPages;

namespace SimpleBindings.Pages
{
        public class CalculateSquareModel : PageModel
        {
            public int Input { get; set; }
            public int Square { get; set; } 



            public void OnGet(int number) 
            {
                Square = number * number; 
                Input = number;
            }
        }
}
