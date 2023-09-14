namespace Server.Domain
{
    public class TaskComment
    {
        public Guid Id { get; set; }
        public string Type { get; set; }
        public string Content { get; set; }

        public Guid? TaskId { get; set; }
        public Task? Task { get; set; }
    }
}
