using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ToDoList.Pages
{
    public class CurrencyModel : PageModel
    {
        /// <summary>
        /// Свойства, декорированные атрибутом [BindProperty], принимают участие в привязке модели
        /// Свойства не будут привязаны к модели для GET-запросов, если вы не используете свойство SupportsGet
        /// </summary>
        
        //[BindProperty(SupportsGet = true)]
        public string Code { get; set; }
        public void OnGet(string code)
        {
            this.Code = code;
        }
    }
}
