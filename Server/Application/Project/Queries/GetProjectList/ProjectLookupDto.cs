using AutoMapper;
using Server.Application.Commons.Mappings;

namespace Server.Application.Project.Queries.GetProjectList
{
    public class ProjectLookupDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdateDate { get; set; }
    }
}
