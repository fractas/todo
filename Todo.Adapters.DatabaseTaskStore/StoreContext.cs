
using Microsoft.EntityFrameworkCore;

using Todo.Adapters.DatabaseTaskStore.Migrations.Configurations;
using Todo.Ports.Entities;

namespace Todo.Adapters.DatabaseTaskStore
{
    public class StoreContext : DbContext
    {
        public StoreContext()
        {

        }

        public StoreContext(DbContextOptions<StoreContext> options)
            : base(options)
        {

        }

        public virtual DbSet<ITask> Tasks { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("server=(localdb)\\MSSQLLocalDB;database=todo;trusted_connection=true;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new TaskEntityTypeConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }
}
