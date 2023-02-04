using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MyTodo.Api.Models.Entities
{
    public class Todo
    {
        protected Todo()
        {
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; private set; }

        public string Title { get; private set; }

        public string Content { get; private set; }

        public int Status { get; private set; }

        public static Todo Create(string title, string content, int status)
        {
            var entity = new Todo()
            {
                Title = title,
                Content = content,
                Status = status
            };
            return entity;
        }

        public Todo SetAllProperty(string title, string content, int status)
        {
            Title = title;
            Content = content;
            Status = status;
            return this;
        }
    }
}