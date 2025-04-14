using System.ComponentModel.DataAnnotations;


namespace InternPortal.Infrastructure.Entities
{
    public class InternEntity
    {
        [Key]
        public Guid Id { get; set; }

        public string FirstName { get; set; } = string.Empty;

        public string LastName { get; set; } = string.Empty;

        public int Gender { get; set; } 

        public string Email { get; set; } = string.Empty;

        public string? PhoneNumber { get; set; }

        public DateTime BirthDate { get; set; }

        public Guid InternshipId { get; set; }

        public InternshipEntity Internship { get; set; }

        public Guid ProjectId { get; set; }

        public ProjectEntity Project { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }
    }
}
