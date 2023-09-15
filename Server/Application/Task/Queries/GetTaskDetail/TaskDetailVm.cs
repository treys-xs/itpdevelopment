using AutoMapper;
using Server.Application.Commons.Mappings;
using Server.Application.Task.Queries.GetTaskList;
using Server.Domain;

namespace Server.Application.Task.Queries.GetTaskDetail
{
    public class TaskDetailVm
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int AmountTime { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
