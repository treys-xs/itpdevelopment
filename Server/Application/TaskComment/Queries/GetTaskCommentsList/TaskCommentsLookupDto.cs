using AutoMapper;
using Server.Application.Commons.Mappings;

namespace Server.Application.TaskComment.Queries.GetTaskCommentsList
{
    public class TaskCommentsLookupDto
    {
        public string Type { get; set; }
        public string Content { get; set; }
    }
}
