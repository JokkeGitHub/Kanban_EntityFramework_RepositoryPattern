using Kanban_EntityFramework_RepositoryPattern.Shared;

namespace Kanban_EntityFramework_RepositoryPattern.Server
{
    public interface IProjectRepository
    {
        IEnumerable<Project> GetAll();
        Project GetById(int id);
        void Insert(Project project);
        void Update(Project project);
        void Delete(int id);
        void Save();
    }
}
