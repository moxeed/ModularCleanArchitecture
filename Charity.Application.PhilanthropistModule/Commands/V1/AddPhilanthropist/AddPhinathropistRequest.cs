using Charity.Application.Module.Wrappers;
using MediatR;

namespace Charity.Application.AdminModule.Commands.V1.AddPhilanthropist
{
    public class AddPhilanthropistRequest : IRequest<Response<int>>
    {
        public string NationalCode { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool? Sex { get; set; }
        
        public string PhoneNumber{ get; set; }
        public string Email{ get; set; }
        public string Tel { get; set; }

        public string StudyField { get; set; }
        public string StudyUniversity { get; set; }
        public string StudyGrade { get; set; }

        public string Occupation { get; set; }
        public string OccupationAddress { get; set; }

        public string FavoriteField { get; set; }
        public string CharityActivitiesHistory { get; set; }

        public int? CityId { get; set; }        
    }
}