using System.ComponentModel.DataAnnotations;

namespace InternPortal.Domain.Models
{
    public class Intern
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

        public Internship Internship { get; set; }

        public Guid ProjectId { get; set; }

        public Project Project { get; set; }

        public DateTime CreateAt { get; set; }

        public DateTime UpdateAt { get; set; }
    }
}
