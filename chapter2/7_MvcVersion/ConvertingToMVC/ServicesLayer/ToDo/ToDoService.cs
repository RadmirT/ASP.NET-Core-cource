using System.Collections.Generic;
using System.Linq;

namespace ConvertingToMVC.ServicesLayer.ToDo
{
    public class ToDoService : IToDoService
    {
        // Обычно эти данные загружаются из БД
        private static readonly List<ToDoListModel> Items = new()
        {
            new ToDoListModel{Category= "Simple", Title="Bread"},
            new ToDoListModel{Category= "Simple", Title="Milk"},
            new ToDoListModel{Category= "Simple", Title="Get Gas"},
            new ToDoListModel{Category= "Long", Title="Write Book"},
            new ToDoListModel{Category= "Long", Title="Build Application"},
        };

        public List<ToDoListModel> GetItemsForCategory(string category)
        {
            // Фильтрация по категориям.
            return Items.Where(x => x.Category == category).ToList();
        }
    }
}