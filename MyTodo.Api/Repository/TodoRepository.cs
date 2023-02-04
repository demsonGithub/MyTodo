namespace MyTodo.Api.Infratructure.Repository
{
    public class TodoRepository : BaseRepository<Todo>, ITodoRepository
    {
        public TodoRepository(AppDbContext dbContext) : base(dbContext)
        {
        }
    }
}