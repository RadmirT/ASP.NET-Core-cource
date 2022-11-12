using System.Collections.Generic;

namespace ToDoList.ServicesLayer;

public interface IToDoService
{
    ICollection<ToDoModel> GetToDoItems(string category, string username);
}