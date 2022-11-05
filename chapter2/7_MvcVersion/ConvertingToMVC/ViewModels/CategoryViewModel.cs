using System.Collections.Generic;
using ConvertingToMVC.ServicesLayer.ToDo;

namespace ConvertingToMVC.ViewModels
{
    public class CategoryViewModel
    {
        public List<ToDoListModel> Items { get; set; }

        public CategoryViewModel(List<ToDoListModel> items)
        {
            this.Items = items;
        }
    }
}
