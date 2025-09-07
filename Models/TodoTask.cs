﻿using Microsoft.EntityFrameworkCore;

namespace ToDoList.Models
{
    public class TodoTask
    {
        public int Id { get; set; }
        public string? Title { get; set; } 
        public bool IsCompleted { get; set; }
        public DateTime CreatedAt { get; set; }
    }

}
