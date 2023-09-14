using AutoMapper;
using Server.Application.Commons.Mappings;

namespace Server.Application.Project.Queries.GetProjectList
{
    public class ProjectLookupDto : IMapWith<Domain.Project>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdateDate { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Domain.Project, ProjectLookupDto>()
                .ForMember(projectDto => projectDto.Id,
                    opt => opt.MapFrom(project => project.Id))
                .ForMember(projectDto => projectDto.CreatedDate,
                    opt => opt.MapFrom(project => project.CreatedDate))
                .ForMember(projectDto => projectDto.UpdateDate,
                    opt => opt.MapFrom(project => project.UpdateDate));
        }
    }
}
