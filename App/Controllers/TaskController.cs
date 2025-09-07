using Microsoft.AspNetCore.Mvc;
using ToDoList.App.DTOs;
using ToDoList.App.Interfaces;
using ToDoList.Models;
using AutoMapper;

namespace ToDoList.App.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private readonly ITaskRepository _taskRepository;
        private readonly IMapper _mapper;

        public TaskController(ITaskRepository taskRepository, IMapper mapper)
        {
            _taskRepository = taskRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TaskDto>>> GetTasks()
        {
            var tasks = await _taskRepository.GetAllTasksAsync();
            var taskDtos = _mapper.Map<IEnumerable<TaskDto>>(tasks);
            return Ok(taskDtos);
        }

        [HttpPost]
        public async Task<ActionResult<TaskDto>> AddTask([FromBody] CreateTaskDto createTaskDto)
        {
            var task = _mapper.Map<TodoTask>(createTaskDto);
            task.CreatedAt = DateTime.UtcNow;

            await _taskRepository.AddTaskAsync(task);

            var taskDto = _mapper.Map<TaskDto>(task);

            return CreatedAtAction(nameof(GetTasks), new { id = task.Id }, taskDto);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<TaskDto>> UpdateTask(int id, [FromBody] UpdateTaskDto updateTaskDto)
        {
            // nếu cần valid thêm thì kiểm tra ModelState
            var task = _mapper.Map<TodoTask>(updateTaskDto);
            task.Id = id;                       // ← gán Id từ route

            await _taskRepository.UpdateTaskAsync(task);

            var taskDto = _mapper.Map<TaskDto>(task);
            return Ok(taskDto);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTask(int id)
        {
            var ok = await _taskRepository.DeleteTaskAsync(id);
            if (!ok) return NotFound();
            return NoContent();
        }
    }
}
