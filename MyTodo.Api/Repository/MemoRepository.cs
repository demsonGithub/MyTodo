namespace MyTodo.Api.Infratructure.Repository
{
    public class MemoRepository : BaseRepository<Memo>, IMemoRepository
    {
        public MemoRepository(AppDbContext dbContext) : base(dbContext)
        {
        }
    }
}