using Charity.Domain.Common;

namespace Charity.Domain.Entities.Core
{
    public class ProjectType : BaseEntity
    {
        public string TypeName { get; set; }
        public string TypeEnName { get; set; }
    }
}
