using Kanban_EntityFramework_RepositoryPattern.Shared;
using System.Data.Entity;

namespace Kanban_EntityFramework_RepositoryPattern.Server
{
    public class ProjectRepository : IProjectRepository
    {
        private readonly KanbanContext _context;

        public ProjectRepository()
        {
            _context = new KanbanContext();
        }

        public ProjectRepository(KanbanContext context)
        {
            _context = context;
        }

        public IEnumerable<Project> GetAll()
        {
            return _context.Projects.ToList<Project>();
        }

        public Project GetById(int id)
        {
            return _context.Projects.Find(id);
        }

        public void Insert(Project project)
        {
            _context.Projects.Add(project);
        }

        public void Update(Project project)
        {
            _context.Entry(project).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            Project project = _context.Projects.Find(id);
            _context.Projects.Remove(project);
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
