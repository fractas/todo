using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using Todo.Ports.Entities;

namespace Todo.Adapters.DatabaseTaskStore.Migrations.Configurations;

public class TaskEntityTypeConfiguration : IEntityTypeConfiguration<ITask>
{
    public void Configure(EntityTypeBuilder<ITask> builder)
    {
        builder.HasKey(pk => pk.Id);
        builder.Property(p => p.Id).HasDefaultValueSql("newsequentialid()").ValueGeneratedOnAdd();
        builder.Property(p => p.Description).IsRequired();
        builder.Property(p => p.Done).HasDefaultValue(false);
    }
}
