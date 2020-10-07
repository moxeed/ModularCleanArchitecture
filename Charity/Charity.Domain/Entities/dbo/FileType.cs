using Charity.Domain.Common;

namespace Charity.Domain.Entities.dbo
{
    public class FileType :BaseEntity
    {
        public string TypeName { get; set; }
        public string TypeEnName { get; set; }
    }
}
