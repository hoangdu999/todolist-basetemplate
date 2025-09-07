using ToDoList.Models;

namespace ToDoList.App.Interfaces
{
    public interface ITaskRepository
    {
        Task<IEnumerable<TodoTask>> GetAllTasksAsync();
        Task AddTaskAsync(TodoTask task);
        Task UpdateTaskAsync(TodoTask task);
        Task<bool> DeleteTaskAsync(int id);  
    }
}
