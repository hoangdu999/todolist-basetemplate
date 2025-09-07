using AutoMapper;
using ToDoList.Models;
using ToDoList.App.DTOs;

namespace ToDoList.App.DTOs
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<TodoTask, TaskDto>().ReverseMap();
            CreateMap<CreateTaskDto, TodoTask>();
        }
    }
}