using System;
using System.Collections.Generic;
using System.Text;

namespace Charity.Application.DTOs
{
    public class CityStateDto
    {
        public int CityId { get; set; }
        public int StateId { get; set; }
        public string CityName { get; set; }
        public string StateName { get; set; }

    }
}
