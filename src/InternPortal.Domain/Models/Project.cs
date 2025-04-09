using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternPortal.Domain.Models
{
    public class Project
    {
        public Project(Guid id, string name, ICollection<Intern> interns, DateTime createdAt)
        {
            Id = id;
            Name = name;
            Interns = interns;
            CreatedAt = createdAt;
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public ICollection<Intern> Interns { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public static (Project Project, string Error) Create(Guid id, string name, ICollection<Intern> interns, DateTime createdAt)
        {
            var error = string.Empty;
            var project = new Project(id, name, interns, createdAt);
            return (project, error);
        }
    }
}
