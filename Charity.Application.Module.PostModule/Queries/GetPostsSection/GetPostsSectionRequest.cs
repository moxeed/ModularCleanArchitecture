using Charity.Application.Module.Parameters;
using Charity.Application.Module.Wrappers;
using Charity.Application.PostModule.DTOs.V1;
using MediatR;

namespace Charity.Application.PostModule.Queries.GetPostsSection
{
    public class GetPostSectionRequest : IRequest<Response<PostSectionDto>>
    {
        public int PostCount { get; set; }
        public int BannerCount { get; set; }
    }
}