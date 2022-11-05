using System.Collections.Generic;

namespace ATypicalRazorPage.ServicesLayer.ToDo;

public interface IToDoService
{
    List<ToDoListModel> GetItemsForCategory(string category);
}