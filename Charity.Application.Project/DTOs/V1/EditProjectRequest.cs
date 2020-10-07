using System;
using Charity.Application.Module.Wrappers;
using MediatR;

namespace Charity.Application.ProjectModule.DTOs.V1
{ 
    public sealed class EditProjectRequest : IRequest<Response<int>>
    {
        public int? Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public long Fund { get; set; }
        public int SurfaceArea { get; set; }
        public int CityId { get; set; }
        public int TypeId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EstimatedEndDate { get; set; }
        public DateTime? ActualEndDate { get; set; }
    }
}
