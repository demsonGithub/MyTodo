namespace MyTodo.Api.Application.AutoMapper
{
    public class TodoProfile : Profile
    {
        public TodoProfile()
        {
            CreateMap<Todo, TodoDetailDto>();
        }
    }
}