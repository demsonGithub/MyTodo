using Microsoft.EntityFrameworkCore;
using MyTodo.Api.Repository.Base;
using MyTodo.Api.Repository.EntityConfigurations;
using System.Threading;
using System.Threading.Tasks;

namespace MyTodo.Api.Infratructure.Repository
{
    public class AppDbContext : EFContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new TodoConfiguration());
            modelBuilder.ApplyConfiguration(new MemoConfiguration());
        }
    }
}