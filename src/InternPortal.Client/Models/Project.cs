namespace InternPortal.Client.Models
{
    public class Project
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public List<Guid> InternIds { get; set; }

        public DateTime CreateAt { get; set; }

        public DateTime UpdateAt { get; set; }
    }
}
