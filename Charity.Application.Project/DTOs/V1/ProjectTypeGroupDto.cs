using System.Collections.Generic;

namespace Charity.Application.ProjectModule.DTOs.V1
{
    public class ProjectTypeGroupDto
    {
        public int TypeId { get; set; }
        public string TypeName { get; set; }
        public IEnumerable<ProjectDto> Projects { get; set; }
    }
}