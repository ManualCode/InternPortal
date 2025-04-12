namespace InternPortal.Domain.Models
{
    public class Internship
    {
        private Internship(Guid id, string name, ICollection<Intern> interns, DateTime createdAt)
        {
            Id = id;
            Name = name;
            Interns = interns;
            CreatedAt = createdAt;
        }

        public Guid Id { get; }

        public string Name { get; }

        public ICollection<Intern> Interns { get; }

        public DateTime CreatedAt { get; }

        public DateTime UpdatedAt { get; } = DateTime.UtcNow;


        public static (Internship Internship, string Error) Create(Guid id, string name, ICollection<Intern> interns, DateTime createdAt)
        {
            var error = string.Empty;
            interns ??= [];
            var internship = new Internship(id, name, interns, createdAt);

            return new(internship, error);
        }
    }
}
