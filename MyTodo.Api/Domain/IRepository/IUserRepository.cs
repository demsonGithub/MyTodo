using MyTodo.Api.Domain.Entities;

namespace MyTodo.Api.Domain.IRepository
{
    public interface IUserRepository : IBaseRepository<User>
    {
        Task<User> GetUserByAccountPwd(string account, string password);
    }
}