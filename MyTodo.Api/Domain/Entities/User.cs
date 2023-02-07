using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyTodo.Api.Domain.Entities
{
    public class User
    {
        protected User()
        {
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; private set; }

        public string UserName { get; private set; }

        public string Account { get; private set; }

        public string Password { get; private set; }

        public static User Create(string username, string account, string password)
        {
            var entity = new User()
            {
                UserName = username,
                Account = account,
                Password = password
            };
            return entity;
        }
    }
}