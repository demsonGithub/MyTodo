using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyTodo.Api.Domain.Entities;

namespace MyTodo.Api.Repository.EntityConfigurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("User");

            builder.HasKey(x => x.Id);
        }
    }
}