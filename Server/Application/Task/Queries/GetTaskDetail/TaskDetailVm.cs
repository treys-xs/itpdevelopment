using AutoMapper;
using Server.Application.Commons.Mappings;
using Server.Application.Task.Queries.GetTaskList;
using Server.Domain;

namespace Server.Application.Task.Queries.GetTaskDetail
{
    public class TaskDetailVm : IMapWith<Domain.Task>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int AmountTime { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime CreatedDate { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Domain.Task, TaskDetailVm>()
                .ForMember(taskDto => taskDto.Name,
                    opt => opt.MapFrom(task => task.Name))
                .ForMember(taskDto => taskDto.AmountTime,
                    opt => opt.MapFrom(task => task.AmountTime))
                .ForMember(taskDto => taskDto.StartDate,
                    opt => opt.MapFrom(task => task.StartDate))
                .ForMember(taskDto => taskDto.EndDate,
                    opt => opt.MapFrom(task => task.EndDate))
                .ForMember(taskDto => taskDto.CreatedDate,
                    opt => opt.MapFrom(task => task.CreatedDate));
        }
    }
}
