using AutoMapper;
using Server.Application.Commons.Mappings;
using Server.Application.Project.Queries.GetProjectList;

namespace Server.Application.Task.Queries.GetTaskList
{
    public class TaskLookupDto : IMapWith<Domain.Task>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int AmountTime { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Domain.Task, TaskLookupDto>()
                .ForMember(taskDto => taskDto.Id,
                    opt => opt.MapFrom(task => task.Id))
                .ForMember(taskDto => taskDto.Name,
                    opt => opt.MapFrom(task => task.Name))
                .ForMember(taskDto => taskDto.Description,
                    opt => opt.MapFrom(task => task.Description))
                .ForMember(taskDto => taskDto.AmountTime,
                    opt => opt.MapFrom(task => task.AmountTime))
                .ForMember(taskDto => taskDto.StartDate,
                    opt => opt.MapFrom(task => task.StartDate))
                .ForMember(taskDto => taskDto.EndDate,
                    opt => opt.MapFrom(task => task.EndDate));
        }
    }
}
