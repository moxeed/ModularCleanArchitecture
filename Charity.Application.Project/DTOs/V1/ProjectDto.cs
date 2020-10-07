using System;
using System.Collections.Generic;
using System.Text;
using Charity.Application.AdminModule.DTOs;
using MediatR;

namespace Charity.Application.ProjectModule.DTOs.V1
{
    public class ProjectDto : INotification
    {
        public int? Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public long Fund { get; set; }
        public int SurfaceArea { get; set; }
        public int CityId { get; set; }
        public string CityName { get; set; }
        public int TypeId { get; set; }
        public string TypeName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EstimatedEndDate { get; set; }
        public DateTime? ActualEndDate { get; set; }

        public PhilanthropistDto Philanthropist { get; set; }
        public IEnumerable<int> ImageIds { get; set; }
    }
}
