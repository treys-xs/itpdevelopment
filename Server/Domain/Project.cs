namespace Server.Domain
{
    public class Project
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdateDate { get; set; }

        public ICollection<Task>? Tasks { get; set; }
    }
}
