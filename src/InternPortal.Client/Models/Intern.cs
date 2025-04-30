using System.ComponentModel.DataAnnotations;

namespace InternPortal.Client.Models
{
    public class Intern
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Введите имя")]
        [StringLength(20, ErrorMessage = "Имя не должно превышать 20 символов")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Введите фамилию")]
        [StringLength(20, ErrorMessage = "Фамилия не должна превышать 20 символов")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Укажите пол")]
        public string Gender { get; set; }

        [Required(ErrorMessage = "Email обязателен")]
        [EmailAddress(ErrorMessage = "Некорректный формат Email")]
        public string Email { get; set; }

        [Phone(ErrorMessage = "Некорректный формат телефона")]
        [RegularExpression(@"^(\+7\d{10})?$", ErrorMessage = "Некорректный номер телефона")]
        public string? PhoneNumber { get; set; }

        [Required(ErrorMessage = "Укажите дату рождения")]
        [DataType(DataType.Date)]
        public DateTime? BirthDate { get; set; }

        [Required(ErrorMessage = "Укажите направление стажирвоки")]
        public string Internship { get; set; }

        [Required(ErrorMessage = "Укажите название проекта")]
        public string Project { get; set; }

        public DateTime CreateAt { get; set; }
        public DateTime UpdateAt { get; set; }
    }
}
