using System.Net.Mail;
using System.Text.RegularExpressions;

namespace InternPortal.Domain.Models
{
    public class Intern
    {
        private Intern(Guid id, string firstName, string lastName, Gender gender, string email, string? phoneNumber,
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

        public string? PhoneNumber { get; }

        public DateTime BirthDate { get; }

        public Internship Internship { get; }

        public Project Project { get; }

        public DateTime CreatedAt { get; }

        public DateTime UpdatedAt { get; } = DateTime.UtcNow;


        public static Intern Create(string firstName, string lastName, Gender gender, string email, string? phoneNumber,
            DateTime birthDate, Internship internship, Project project, DateTime createdAt, Guid? id = null)
        {
            MailAddress? _mail;

            if (string.IsNullOrWhiteSpace(email) && !MailAddress.TryCreate(email, out _mail))
                throw new Exception("Неккоректный адрес");

            if (!string.IsNullOrWhiteSpace(phoneNumber) && !Regex.IsMatch(phoneNumber, @"^(\+7\d{10})?$"))
                throw new Exception("Некорректный номер телефона");

            return new Intern(id ?? Guid.NewGuid(), firstName, lastName, gender, email, phoneNumber, birthDate, internship, project, createdAt);
        }
    }
}
