using Microsoft.EntityFrameworkCore;
using ToDoList.App.Interfaces;
using ToDoList.Data;
using ToDoList.Models;

namespace ToDoList.App.Repositories
{
    public class TaskRepository : ITaskRepository
    {
        private readonly ApplicationDbContext _context;

        public TaskRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<TodoTask>> GetAllTasksAsync()
        {
            return await _context.Tasks.ToListAsync();
        }

        public async Task AddTaskAsync(TodoTask task)
        {
            await _context.Tasks.AddAsync(task);
            await _context.SaveChangesAsync();
        }
        public async Task UpdateTaskAsync(TodoTask task)
        {
            _context.Tasks.Update(task);
            await _context.SaveChangesAsync();
        }
        public async Task<bool> DeleteTaskAsync(int id)
        {
            var entity = await _context.Tasks.FindAsync(id);
            if (entity == null) return false;

            _context.Tasks.Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
