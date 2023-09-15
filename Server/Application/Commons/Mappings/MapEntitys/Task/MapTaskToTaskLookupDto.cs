using AutoMapper;
using Server.Application.Task.Queries.GetTaskList;

namespace Server.Application.Commons.Mappings.MapEntitys.Task
{
    public class MapTaskToTaskLookupDto : Profile
    {
        public MapTaskToTaskLookupDto()
        {
            CreateMap<Domain.Task, TaskLookupDto>();
        }
    }
}
