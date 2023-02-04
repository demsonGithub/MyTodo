namespace MyTodo.Api.Infratructure.Repository.Base
{
    public interface IUnitOfWork : IDisposable
    {
        Task<bool> SaveEntitiesAsync(CancellationToken cancellationToken = default);
    }
}