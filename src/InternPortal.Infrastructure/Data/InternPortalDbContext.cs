using InternPortal.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;


namespace InternPortal.Infrastructure.Data
{
    public class InternPortalDbContext : DbContext
    {
        public InternPortalDbContext(DbContextOptions<InternPortalDbContext> options) : base(options)
        {

        }

        public DbSet<InternEntity> Interns { get; set; }
        public DbSet<InternshipEntity> Internships { get; set; }
        public DbSet<ProjectEntity> Projects { get; set; }
    }
}
