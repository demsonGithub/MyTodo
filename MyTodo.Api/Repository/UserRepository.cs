using MyTodo.Api.Domain.Entities;
using MyTodo.Api.Infratructure.Repository;
using System.Threading.Tasks;

namespace MyTodo.Api.Repository
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        private readonly AppDbContext _dbContext;

        public UserRepository(AppDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<User> GetUserByAccountPwd(string account, string password)
        {
            var query = _dbContext.Set<User>().Where(i => i.Account == account && i.Password == password);

            var entity = await query.FirstOrDefaultAsync();

            return entity;
        }
    }
}