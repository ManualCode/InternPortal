﻿using System.ComponentModel.DataAnnotations;

namespace InternPortal.Client.Models
{
    public class Project
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public List<Guid> Interns { get; set; }

        public DateTime CreateAt { get; set; }

        public DateTime UpdateAt { get; set; }
    }
}
