using dotnet_healthAPI_backend.Data;
using dotnet_healthAPI_backend.Models;
using dotnet_healthAPI_backend.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotnet_healthAPI_backend.Services
{
    public class WellnessService : IWellnessService
    {
        private readonly HealthAPIContext _context;
        public WellnessService(HealthAPIContext context)
        {
            _context = context;
        }

        public async Task<ActionResult<IEnumerable>> GetAllWellnessById(int idUser)
        {
            return await _context.Wellness.Where(c => c.UserId == idUser).ToListAsync();

        }
        public async Task<ActionResult<Wellness>> CreateWellnessByUser(Wellness wellness)
        {
            if (wellness.Id != 0)
            {
                _context.Entry(wellness).State = EntityState.Modified;
            }
            else
            {
                _context.Wellness.Add(wellness);
            }
                await _context.SaveChangesAsync();
            return wellness;
        }

        
    }
}
