using Charity.Application.DTOs;
using Charity.Application.Interfaces;
using Charity.Infrastructure.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Charity.Infrastructure.Persistence.Services
{
    public class ConstantService : IConstantService
    {
        private readonly ApplicationDbContext _context;

        public ConstantService(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<CityStateDto> GetCityStates()
        {
            return _context.Cities.Include(c => c.State).Select(c => new CityStateDto
            {
                CityId = c.Id,
                StateId = c.StateId,
                CityName = c.Name,
                StateName = c.State.Name
            });
        }
    }
}
