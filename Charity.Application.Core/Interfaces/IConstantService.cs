using Charity.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Charity.Application.Interfaces
{
    public interface IConstantService
    {
        IEnumerable<CityStateDto> GetCityStates();
    }
}
