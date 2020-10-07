using Charity.Domain.Entities.dbo;

namespace Charity.Application.AdminModule.DTOs
{
    public class PhilanthropistDto
    {
        public string Id { get; set; }
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
        
        public long SparedFund { get; set; }
        public int ProjectCounts { get; set; }

        public int CityId { get; set; }
        public string CityName { get; set; }

        public int ImageId { get; set; } = 1;
    }
}