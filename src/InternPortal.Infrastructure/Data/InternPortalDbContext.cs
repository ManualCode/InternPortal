using InternPortal.Domain.Models;
using Microsoft.EntityFrameworkCore;


namespace InternPortal.Infrastructure.Data
{
    public class InternPortalDbContext : DbContext
    {
        public InternPortalDbContext(DbContextOptions<InternPortalDbContext> options) : base(options)
        {

        }

        public DbSet<Intern> Interns { get; set; }
        public DbSet<Internship> Internships { get; set; }
        public DbSet<Project> Projects { get; set; }
    }
}
