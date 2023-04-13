namespace Kanban_EntityFramework_RepositoryPattern.Shared
{
    public class TaskItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Points { get; set; }
        public string SectionIdentifier { get; set; }

        public TaskItem(int id, string name, string description, int points, string sectionIdentifier)
        {
            Id = id;
            Name = name;
            Description = description;
            Points = points;
            SectionIdentifier = sectionIdentifier;
        }
    }
}
