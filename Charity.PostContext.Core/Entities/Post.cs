using System.Collections.Generic;
using Charity.Domain.Common;
using Charity.Domain.Entities;

namespace Charity.PostContext.Core.Entities
{
    public class Post : AuditableBaseEntity
    {
        public string Title { get; set; }
        public string Summary { get; set; }
        public string Content { get; set; }

        public ICollection<UploadedFile> Files { get; set; }
    }
}
