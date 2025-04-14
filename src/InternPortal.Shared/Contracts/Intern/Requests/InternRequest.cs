using System.ComponentModel.DataAnnotations;

namespace InternPortal.Shared.Contracts.Intern.Requests
{
    public sealed record InternRequest(
        [Required]
        string FirstName,
        [Required]
        string LastName,
        [Required]
        string Gender,
        [Required][EmailAddress(ErrorMessage = "Некорректный адресс")]
        string Email,
        [RegularExpression(@"^(\+7\d{10})?$", ErrorMessage = "Некорректный номер телефона")]
        string? PhoneNumber,
        [Required]
        DateTime BirthDate,
        [Required]
        string Internship,
        [Required]
        string Project,
        DateTime CreatedAt,
        DateTime UpdateAt
    );
}
