using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace SampleApplication.Pages
{
    public class IndexModel : PageModel
    {
        /// <summary>
        /// Создаем один экземпляр каждой группы для передачи элементам SelectListItem
        /// </summary>
        private static readonly SelectListGroup _dynamicGroup = new SelectListGroup { Name = "Dynamic Languages" };
        private static readonly SelectListGroup _staticGroup = new SelectListGroup { Name = "Static Languages" };

        public ICollection<SelectListItem> Items => this.ItemsWithGroups
            .Select(item => new SelectListItem
            {
                Value = item.Value,
                Text = item.Text
            })
            .ToList();

        
        //Список элементов для отображения в полях выбора
        public ICollection<SelectListItem> ItemsWithGroups { get; set; } = new List<SelectListItem> 
        {
           new SelectListItem
           {
               Value= "javascript",
               Text="JavaScript",
               Group = _dynamicGroup //Задаем соответствующую группу для каждого элемента SelectListItem
           },
           new SelectListItem{Value= "cpp", Text="C++", Group = _staticGroup},
           new SelectListItem{Value= "python", Text= "Python", Group = _dynamicGroup},
           new SelectListItem
           {
               Value= "csharp",
               Text="C#" 
               //Если у элемента SelectListItem нет группы, он не будет добавлен в <optgroup>
           },
        };

        [BindProperty]
        public InputModel Input { get; set; } // InputModel для привязки выбора пользователя к полям выбора 
        public bool ShowResults {get;set;}

        public void OnGet()
        {
        }

        public void OnPost()
        {
            this.ShowResults = true;
        }

        public class InputModel
        {
            // Эти свойства будут содержать значения, выбранные в полях с возможностью выбора одного варианта
            public string SelectedValue1 { get; set; } 
            public string SelectedValue2 { get; set; }

            // Эти свойства будут содержать значения, выбранные в полях с возможностью множественного выбора.
            public IEnumerable<string> MultiValues1 { get; set; } = new List<string>();  
            public IEnumerable<string> MultiValues2 { get; set; } = new List<string>();
        }
    }
}
