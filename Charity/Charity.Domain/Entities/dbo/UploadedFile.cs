using Charity.Domain.Common;
using Charity.Domain.Entities.Core;

namespace Charity.Domain.Entities.dbo
{
    public class UploadedFile : AuditableBaseEntity
    {
        public string FileName { get; set; }
        public string FilePath { get; set; }

        public int? PostId { get; set; }
        public Post Post { get; set; }
        
        public int? ProjectId { get; set; }
        public Project Project { get; set; }
        public int TypeId { get; set; }
        public FileType Type { get; set; }
    }
}
