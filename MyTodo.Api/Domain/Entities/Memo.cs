using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyTodo.Api.Models.Entities
{
    public class Memo
    {
        protected Memo()
        {
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; private set; }

        public string Title { get; private set; }

        public string Content { get; private set; }

        public static Memo Create(string title, string content)
        {
            var entity = new Memo
            {
                Title = title,
                Content = content
            };
            return entity;
        }

        public Memo SetAllProperty(string title, string content)
        {
            Title = title;
            Content = content;

            return this;
        }
    }
}