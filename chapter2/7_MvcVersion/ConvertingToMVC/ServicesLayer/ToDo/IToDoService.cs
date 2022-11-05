using System.Collections.Generic;

namespace ConvertingToMVC.ServicesLayer.ToDo;

public interface IToDoService
{
    List<ToDoListModel> GetItemsForCategory(string category);
}