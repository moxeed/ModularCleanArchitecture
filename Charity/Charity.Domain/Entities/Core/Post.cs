using System.Collections.Generic;
using Charity.Domain.Common;
using Charity.Domain.Entities.dbo;

namespace Charity.Domain.Entities.Core
{
    public class Post : AuditableBaseEntity
    {
        public string Title { get; set; }
        public string Summary { get; set; }
        public string Content { get; set; }

        public ICollection<UploadedFile> Files { get; set; }
    }
}
