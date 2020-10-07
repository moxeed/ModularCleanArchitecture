using System.Linq;
using AutoMapper;
using Charity.Application.ProjectModule.Commands.V1.AddProjectType;
using Charity.Application.ProjectModule.Commands.V1.DeleteProjectType;
using Charity.Application.ProjectModule.DTOs.V1;
using Charity.Domain.Entities.Core;

namespace Charity.Application.ProjectModule.Mapping
{
    public class ProjectProfile : Profile
    {
        public ProjectProfile()
        {
            CreateMap<AddProjectRequest, Project>();
            CreateMap<EditProjectRequest, Project>();
            CreateMap<DeleteProjectRequest, Project>();
            CreateMap<AddProjectTypeRequest, ProjectType>();
            CreateMap<DeleteProjectTypeRequest, ProjectType>();
            CreateMap<Project, ProjectDto>().ForMember(c => c.CityName,o => o.MapFrom(s => s.City.Name)).
                ForMember(c => c.Philanthropist,o => o.MapFrom(s => s.Philanthropist)).
                ForMember(c => c.TypeName, o => o.MapFrom(s => s.Type.TypeName)).
                ForMember(c => c.ImageIds, o => o.MapFrom(p => p.AttachedFiles.Select(x =>x.Id)));
            
            CreateMap<ProjectType, ProjectTypeDto>();
        }
    }
}
