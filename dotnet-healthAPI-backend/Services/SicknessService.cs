using dotnet_healthAPI_backend.Data;
using dotnet_healthAPI_backend.DTO;
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
            List<SicknessDTO> list = new List<SicknessDTO>();
            var sickness = await _context.Sickness.ToListAsync();
            foreach (var item in sickness)
            {
                list.Add(SicknessToDTO(item));
            }
            return list;
        }

        public async Task<ActionResult<SicknessDTO>> GetSicknessById(int id)
        {
            var sickness = await _context.Sickness.FindAsync(id);
            if (sickness == null)
            {
                return new SicknessDTO();
            }
            return SicknessToDTO(sickness);
        }

        public async Task<ActionResult<SicknessDTO>> CreateSickness(Sickness sickness)
        {
            _context.Sickness.Add(sickness);
            await _context.SaveChangesAsync();

            return SicknessToDTO(sickness);
        }

        public async Task<ActionResult<SicknessDTO>> UpdateSickness(Sickness sickness)
        {
            try
            {
                _context.Entry(sickness).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                return SicknessToDTO(sickness);
            }
            catch (Exception ex)
            {
                throw new Exception("Record cannot updated", ex);
            }

        }

        public async Task<ActionResult<SicknessDTO>> DeleteSickness(int id)
        {
            var sickness = await _context.Sickness.FindAsync(id);
            if (sickness == null)
            {
                return new SicknessDTO();
            }
            _context.Sickness.Remove(sickness);
            await _context.SaveChangesAsync();
            return SicknessToDTO(sickness);
        }

        private static SicknessDTO SicknessToDTO(Sickness sickness) =>
        new SicknessDTO
        {
            Id = sickness.Id,
            Name = sickness.Name,
            ScientificNotation = sickness.ScientificNotation,
            Description = sickness.Description,
            ImageUrl = sickness.ImageUrl
        };
    }
}
