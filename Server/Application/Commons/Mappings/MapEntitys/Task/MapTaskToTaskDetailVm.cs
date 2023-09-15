using AutoMapper;
using Server.Application.Task.Queries.GetTaskDetail;

namespace Server.Application.Commons.Mappings.MapEntitys.Task
{
    public class MapTaskToTaskDetailVm : Profile
    {
        public MapTaskToTaskDetailVm()
        {
            CreateMap<Domain.Task, TaskDetailVm>();
        }
    }
}
