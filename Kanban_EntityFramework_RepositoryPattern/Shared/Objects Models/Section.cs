namespace Kanban_EntityFramework_RepositoryPattern.Shared
{
    public class Section
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int ProjectId { get; set; }

        public Section(int id, string name, int projectId)
        {
            Id = id;
            Name = name;
            ProjectId = projectId;
        }
    }
}
