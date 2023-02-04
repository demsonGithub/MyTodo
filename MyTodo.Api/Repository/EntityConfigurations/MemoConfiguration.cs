using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MyTodo.Api.Repository.EntityConfigurations
{
    public class MemoConfiguration : IEntityTypeConfiguration<Memo>
    {
        public void Configure(EntityTypeBuilder<Memo> builder)
        {
            builder.ToTable("Memo");
            builder.HasKey(t => t.Id);
        }
    }
}