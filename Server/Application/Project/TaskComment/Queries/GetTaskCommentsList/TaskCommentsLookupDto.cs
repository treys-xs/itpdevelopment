using AutoMapper;
using Server.Application.Commons.Mappings;

namespace Server.Application.Project.TaskComment.Queries.GetTaskCommentsList
{
    public class TaskCommentsLookupDto : IMapWith<Domain.TaskComment>
    {
        public string Type { get; set; }
        public string Content { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Domain.TaskComment, TaskCommentsLookupDto>()
                .ForMember(taskCommentDto=> taskCommentDto.Type,
                    opt => opt.MapFrom(taskComment => taskComment.Type))
                .ForMember(projectDto => projectDto.Content,
                    opt => opt.MapFrom(project => project.Content));
        }
    }
}
