using System.Linq;
using AutoMapper;
using Charity.Application.AdminModule.Commands.V1.AddPhilanthropist;
using Charity.Application.AdminModule.Commands.V1.EditPhilanthropist;
using Charity.Application.AdminModule.DTOs;
using Charity.Domain.Entities.Core;

namespace Charity.Application.AdminModule.Mappings
{
    public class PhilanthropistProfile : Profile
    {
        public PhilanthropistProfile()
        {
            CreateMap<AddPhilanthropistRequest, Philanthropist>();
            CreateMap<EditPhilanthropistRequest, Philanthropist>();
            CreateMap<Philanthropist, PhilanthropistDto>().ForMember(p => p.CityName,
                s => s.MapFrom( s => s.City.Name))
                .ForMember(c => c.SparedFund, 
                    s => s.MapFrom(s => s.Projects.Sum(c=> c.Fund)))
                .ForMember(c => c.ProjectCounts, 
                s => s.MapFrom(s => s.Projects.Count));
        }
    }
}