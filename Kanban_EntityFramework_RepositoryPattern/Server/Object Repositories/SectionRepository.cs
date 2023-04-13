using Kanban_EntityFramework_RepositoryPattern.Shared;
using System.Data.Entity;

namespace Kanban_EntityFramework_RepositoryPattern.Server
{
    public class SectionRepository : ISectionRepository
    {
        private readonly KanbanContext _context;

        public SectionRepository()
        {
            _context = new KanbanContext();
        }

        public SectionRepository(KanbanContext context)
        {
            _context = context;
        }

        public IEnumerable<Section> GetAll()
        {
            return _context.Sections.ToList();
        }

        public Section GetById(int id)
        {
            return _context.Sections.Find(id);
        }

        public void Insert(Section section)
        {
            _context.Sections.Add(section);
        }

        public void Update(Section section)
        {
            _context.Entry(section).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            Section section = _context.Sections.Find(id);
            _context.Sections.Remove(section);
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
