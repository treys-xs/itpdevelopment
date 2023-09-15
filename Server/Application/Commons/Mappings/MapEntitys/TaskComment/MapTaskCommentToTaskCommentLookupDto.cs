using AutoMapper;
using Server.Application.TaskComment.Queries.GetTaskCommentsList;

namespace Server.Application.Commons.Mappings.MapEntitys.TaskComment
{
    public class MapTaskCommentToTaskCommentLookupDto : Profile
    {
        public MapTaskCommentToTaskCommentLookupDto()
        {
            CreateMap<Domain.TaskComment, TaskCommentsLookupDto>();
        }
    }
}
