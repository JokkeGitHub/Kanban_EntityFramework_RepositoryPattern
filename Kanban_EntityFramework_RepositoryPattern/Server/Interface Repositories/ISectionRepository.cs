using Kanban_EntityFramework_RepositoryPattern.Shared;

namespace Kanban_EntityFramework_RepositoryPattern.Server
{
    public interface ISectionRepository
    {
        IEnumerable<Section> GetAll();
        Section GetById(int id);
        void Insert(Section section);
        void Update(Section section);
        void Delete(int id);
        void Save();
    }
}
