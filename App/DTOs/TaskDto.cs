namespace ToDoList.App.DTOs
{
    public class TaskDto
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public bool IsCompleted { get; set; }
        public DateTime CreatedAt { get; set; }
    }

    public class CreateTaskDto
    {
        public string? Title { get; set; }
        public bool IsCompleted { get; set; }
    }
    public class UpdateTaskDto
    {
        public string? Title { get; set; }
        public bool IsCompleted { get; set; }
    }
}