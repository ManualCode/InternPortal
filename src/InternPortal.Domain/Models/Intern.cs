namespace InternPortal.Domain.Models
{
    public class Intern
    {
        private Intern(Guid id, string firstName, string lastName, Gender gender, string email, string phoneNumber,
            DateTime birthDate, Internship internship, Project project, DateTime createdAt)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Gender = gender;
            Email = email;
            BirthDate = birthDate;
            PhoneNumber = phoneNumber;
            Internship = internship;
            Project = project;
            CreatedAt = createdAt;
        }

        public Guid Id { get; }

        public string FirstName { get; }

        public string LastName { get; }

        public Gender Gender { get; }

        public string Email { get; }

        public string PhoneNumber { get; }

        public DateTime BirthDate { get; }

        public Internship Internship { get; }

        public Project? Project { get; }

        public DateTime CreatedAt { get; }

        public DateTime UpdatedAt { get; } = DateTime.UtcNow;


        public static (Intern Intern, string Error) Create(string firstName, string lastName, Gender gender, string email, string phoneNumber,
            DateTime birthDate, Internship internship, Project project, DateTime createdAt)
        {
            var error = string.Empty;
            var intern = new Intern(Guid.NewGuid(), firstName, lastName, gender, email, phoneNumber, birthDate, internship, project, createdAt);

            return (intern, error);
        }
    }
}
