namespace InternPortal.Domain.Models
{
    public class Project
    {
        public Project(Guid id, string name, ICollection<Guid> internIds, DateTime createdAt)
        {
            Id = id;
            Name = name;
            InternIds = internIds;
            CreatedAt = createdAt;
        }

        public Guid Id { get; }
        public string Name { get; }
        public ICollection<Guid> InternIds { get; }
        public DateTime CreatedAt { get; }
        public DateTime UpdatedAt { get; }

        public static Project Create(string name, ICollection<Guid> internIds, DateTime createdAt, Guid? id = null)
            => new Project(id ?? Guid.NewGuid(), name, internIds, createdAt);
    }
}
