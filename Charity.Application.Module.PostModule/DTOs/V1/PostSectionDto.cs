using System.Collections.Generic;

namespace Charity.Application.PostModule.DTOs.V1
{
    public class PostSectionDto
    {
        public IEnumerable<PostDto> Posts { get; set; }
        public IEnumerable<PostBannerDto> BannerPosts { get; set; }
    }
}