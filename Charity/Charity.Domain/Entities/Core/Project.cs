using System;
using System.Collections.Generic;
using Charity.Domain.Common;
using Charity.Domain.Entities.dbo;

namespace Charity.Domain.Entities.Core
{
    public class Project : AuditableBaseEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public long Fund { get; set; }
        public int SurfaceArea { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EstimatedEndDate { get; set; }
        public DateTime? ActualEndDate { get; set; }

        public int? CityId { get; set; }
        public City City { get; set; }
        public int TypeId { get; set; }
        public ProjectType Type { get; set; }
        
        public int PhilanthropistId { get; set; }
        public Philanthropist Philanthropist { get; set; }
        
        public ICollection<UploadedFile> AttachedFiles { get; set; }
        public ICollection<ProjectDynamicData> ExtraDataCollection { get; set; }
    }
}
