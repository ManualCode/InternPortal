using System.ComponentModel.DataAnnotations;


namespace InternPortal.Infrastructure.Entities
{
    public class InternshipEntity
    {
        [Key]
        public Guid Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public DateTime BirthDate { get; set; }

        public ICollection<InternEntity> Interns { get; set; } = [];

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
    }
}
