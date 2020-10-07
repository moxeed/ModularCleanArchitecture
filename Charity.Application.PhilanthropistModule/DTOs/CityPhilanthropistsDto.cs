using System.Collections;
using System.Collections.Generic;

namespace Charity.Application.AdminModule.DTOs
{
    public class CityPhilanthropistsDto
    {
        public int CityId { get; set; }
        public IEnumerable<PhilanthropistDto> Philanthropists { get; set; }
    }
}