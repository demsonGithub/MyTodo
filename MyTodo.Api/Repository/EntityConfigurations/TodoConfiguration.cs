using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MyTodo.Api.Repository.EntityConfigurations
{
    public class TodoConfiguration : IEntityTypeConfiguration<Todo>
    {
        public void Configure(EntityTypeBuilder<Todo> builder)
        {
            builder.ToTable("Todo");
            builder.HasKey(t => t.Id);
        }
    }
}