using Kanban_EntityFramework_RepositoryPattern.Shared;
using System.Data.Entity;

namespace Kanban_EntityFramework_RepositoryPattern.Server
{
    public class TaskItemRepository : ITaskItemRepository
    {
        private readonly KanbanContext _context;

        public TaskItemRepository()
        {
            _context = new KanbanContext();
        }

        public TaskItemRepository(KanbanContext context)
        {
            _context = context;
        }

        public IEnumerable<TaskItem> GetAll()
        {
            return _context.TaskItems.ToList();
        }

        public TaskItem GetById(int id)
        {
            return _context.TaskItems.Find(id);
        }

        public void Insert(TaskItem taskItem)
        {
            _context.TaskItems.Add(taskItem);
        }

        public void Update(TaskItem taskItem)
        {
            _context.Entry(taskItem).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            TaskItem taskItem = _context.TaskItems.Find(id);
            _context.TaskItems.Remove(taskItem);
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);

            GC.SuppressFinalize(this);
        }
    }
}
