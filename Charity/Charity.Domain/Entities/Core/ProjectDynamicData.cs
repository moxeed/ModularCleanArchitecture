using Charity.Domain.Common;

namespace Charity.Domain.Entities.Core
{
    public class ProjectDynamicData : BaseEntity
    {
        public string Name { get; set; }
        public string Value { get; set; }

        public int ProjectId { get; set; }
        public Project Project { get; set; }
    }
}
