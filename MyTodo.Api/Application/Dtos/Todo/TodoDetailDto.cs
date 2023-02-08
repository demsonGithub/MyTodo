namespace MyTodo.Api.Application.Dtos
{
    public class TodoDetailDto
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public int Status { get; set; }
    }
}