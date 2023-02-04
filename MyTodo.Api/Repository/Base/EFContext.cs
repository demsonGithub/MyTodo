using System.Threading;
using System.Threading.Tasks;

namespace MyTodo.Api.Repository.Base
{
    public class EFContext : DbContext, IUnitOfWork
    {
        public EFContext(DbContextOptions options) : base(options)
        {
        }

        public async Task<bool> SaveEntitiesAsync(CancellationToken cancellationToken = default)
        {
            try
            {
                await base.SaveChangesAsync(cancellationToken);
            }
            catch (Exception ex)
            {
                return false;
            }

            return true;
        }
    }
}