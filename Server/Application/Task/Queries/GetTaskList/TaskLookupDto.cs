using AutoMapper;
using Server.Application.Commons.Mappings;
using Server.Application.Project.Queries.GetProjectList;

namespace Server.Application.Task.Queries.GetTaskList
{
    public class TaskLookupDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int AmountTime { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
