using AutoMapper;
using Server.Application.Project.Queries.GetProjectList;

namespace Server.Application.Commons.Mappings.MapEntitys.Project
{
    public class MapProjectToProjectLookupDto : Profile
    {
        public MapProjectToProjectLookupDto()
        {
            CreateMap<Domain.Project, ProjectLookupDto>();
        }
    }
}
