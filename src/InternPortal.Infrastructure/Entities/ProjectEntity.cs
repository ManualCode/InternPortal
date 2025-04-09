using System.ComponentModel.DataAnnotations;


namespace InternPortal.Infrastructure.Entities
{
    public class ProjectEntity
    {
        [Key]
        public Guid Id { get; set; 
        }
        public string Name { get; set; }

        public ICollection<InternEntity> Interns { get; set; } = [];

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }
    }
}
