using Kanban_EntityFramework_RepositoryPattern.Shared;

namespace Kanban_EntityFramework_RepositoryPattern.Server
{
    public interface ITaskItemRepository
    {
        IEnumerable<TaskItem> GetAll();
        TaskItem GetById(int id);
        void Insert(TaskItem taskItem);
        void Update(TaskItem taskItem);
        void Delete(int id);
        void Save();
    }
}
