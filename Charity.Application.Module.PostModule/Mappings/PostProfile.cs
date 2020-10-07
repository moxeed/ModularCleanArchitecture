using System.Globalization;
using System.Linq;
using AutoMapper;
using Charity.Application.PostModule.Commands.V1.AddPost;
using Charity.Application.PostModule.Commands.V1.EditPost;
using Charity.Application.PostModule.DTOs.V1;
using Charity.Domain.Entities.Core;

namespace Charity.Application.PostModule.Mappings
{
    public class PostProfile : Profile
    {
        public PostProfile()
        {
            CreateMap<AddPostRequest, Post>();
            CreateMap<EditPostRequest, Post>();
            CreateMap<Post,PostDto>().ForMember(c => c.CreateDate,
                s => s.MapFrom(c => c.Created.ToString(CultureInfo.InvariantCulture))).
                ForMember(c => c.ImageIds, o => o.MapFrom(s => s.Files.Select(s => s.Id)));

            CreateMap<Post, PostBannerDto>().ForMember(c => c.CreateDate,
                s => s.MapFrom(c => c.Created.ToString(CultureInfo.InvariantCulture)));;
        }
    }
}