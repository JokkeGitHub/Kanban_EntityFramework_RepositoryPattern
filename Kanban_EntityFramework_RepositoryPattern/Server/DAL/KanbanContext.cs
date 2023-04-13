using Kanban_EntityFramework_RepositoryPattern.Shared;
using System.Data.Entity;

namespace Kanban_EntityFramework_RepositoryPattern.Server
{
    public class KanbanContext : DbContext
    {
        public KanbanContext() : base("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=KanbanDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False")
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //base.OnModelCreating(modelBuilder);
            throw new NotImplementedException();
        }

        public virtual DbSet<Project> Projects { get; set; }
        public virtual DbSet<Section> Sections { get; set; }
        public virtual DbSet<TaskItem> TaskItems { get; set; }
    }
}
