namespace InternPortal.Client.Models
{
    public class InternForList
    {
        public Guid id { get; set; }

        public string FullName { get; set; }

        public string Gender { get; set; }

        public string Email { get; set; }

        public string? PhoneNumber { get; set; }

        public DateTime BirthDate { get; set; }

        public Internship Internship { get; set; }

        public Project Project { get; set; }
        
    }
}
