namespace InternPortal.Client.Models
{
    public class PagedInternships
    {
        public int TotalCount { get; set; }
        public List<Internship> Internships { get; set; }
    }
}
