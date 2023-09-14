namespace Server.Domain
{
    public class Task
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int AmountTime { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set;}

        public Guid? ProjectId { get; set; }
        public Project? Project { get; set; }

        public ICollection<TaskComment>? TaskComments { get; set; }
    }
}
