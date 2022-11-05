using ConvertingToMVC.ServicesLayer.ToDo;
using ConvertingToMVC.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace ConvertingToMVC.Controllers
{
    public class ToDoController : Controller
    {
        
        private readonly IToDoService service; // ToDoService предоставляется в конструкторе контроллера с использованием внедрения зависимостей 

        public ToDoController(IToDoService service)
        {
            this.service = service;
        }


        public ActionResult Category(string id) //Метод действия Category принимает параметр id  из Url запроса
        {
            var items = this.service.GetItemsForCategory(id);
            // Модель представления - это простой класс C#, определенный в другом месте вашего приложения 
            var viewModel = new CategoryViewModel(items);
            //Возвращает объект ViewResult, указывающий на то, что должно быть визуализировано представление, передавая модель представления 
            return this.View(viewModel);
        }
    }
}