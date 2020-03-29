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
    public class SicknessService : ISicknessService
    {
        private readonly HealthAPIContext _context;
        public SicknessService(HealthAPIContext context)
        {
            _context = context;
        }

        public async Task<ActionResult<IEnumerable>> GetAllSickness()
        {
            return await _context.Sickness.ToListAsync();
        }

        public async Task<ActionResult<Sickness>> GetSicknessById(int id)
        {
            var sickness = await _context.Sickness.FindAsync(id);
            if (sickness == null)
            {
                return new Sickness();
            }
            return sickness;
        }

        public async Task<ActionResult<Sickness>> CreateSickness(Sickness sickness)
        {
            _context.Sickness.Add(sickness);
            await _context.SaveChangesAsync();

            return sickness;
        }

        public async Task<ActionResult<Sickness>> UpdateSickness(int id, Sickness sickness)
        {
            if (id != sickness.Id)
            {
                return new Sickness();
            }

            _context.Entry(sickness).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return sickness;
        }

        public async Task<ActionResult<Sickness>> DeleteSickness(int id)
        {
            var sickness = await _context.Sickness.FindAsync(id);
            if (sickness == null)
            {
                return new Sickness();
            }
            _context.Sickness.Remove(sickness);
            await _context.SaveChangesAsync();
            return sickness;
        }
    }
}
