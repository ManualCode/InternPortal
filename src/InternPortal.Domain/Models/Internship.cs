namespace InternPortal.Domain.Models
{
    public class Internship
    {
        private Internship(Guid id, string name, ICollection<Guid> internIds, DateTime createdAt)
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

        public DateTime UpdatedAt { get; } = DateTime.UtcNow;


        public static Internship Create(string name, ICollection<Guid> interns, DateTime createdAt, Guid? id = null)
            => new Internship(id ?? Guid.NewGuid(), name, interns, createdAt);
    }
}
