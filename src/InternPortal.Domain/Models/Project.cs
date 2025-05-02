using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InternPortal.Domain.Models
{
    public class Project
    {
        [Key]
        public Guid Id { get; set;}

        public string Name { get; set; }

        [NotMapped]
        public ICollection<Guid> InternIds { get; set; } = [];

        public ICollection<Intern> Interns { get; set; } = [];

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }
    }
}
