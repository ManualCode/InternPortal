namespace InternPortal.Domain.Models
{
    public class Project
    {
        public Project(Guid id, string name, ICollection<Intern> interns, DateTime createdAt)
        {
            Id = id;
            Name = name;
            Interns = interns;
            CreatedAt = createdAt;
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public ICollection<Intern> Interns { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public static Project Create(string name, ICollection<Intern> interns, DateTime createdAt, Guid? id = null)
            => new Project(id ?? Guid.NewGuid(), name, interns, createdAt);
    }
}
