using System.Collections.Generic;
using System.Transactions;

namespace Charity.Application.PostModule.DTOs.V1
{
    public class PostDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string MainImageId { get; set; }
        
        public string Summary { get; set; }
        public string Content { get; set; }
        public string CreateDate { get; set; }
        public string AuthorId { get; set; }
        public string AuthorName { get; set; }

        public IEnumerable<int> ImageIds { get; set; } 
    }
}