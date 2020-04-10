using dotnet_healthAPI_backend.Data;
using dotnet_healthAPI_backend.Models;
using dotnet_healthAPI_backend.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace dotnet_healthAPI_backend.Services
{
    public class MedicalHistoryService : IMedicalHistoryService
    {
        private readonly HealthAPIContext _context;
        public MedicalHistoryService(HealthAPIContext context)
        {
            _context = context;
        }

        public async Task<ActionResult<IEnumerable>> GetAllMedicalHistoryById(int idUser)
        {
            return await _context.MedicalHistory.Where(c => c.UserId == idUser).ToListAsync();
        }

        public async Task<ActionResult<MedicalHistory>> CreateMedicalHistoryByUser(MedicalHistory medicalHistory)
        {

            var ususave = _context.MedicalHistory.Add(medicalHistory);
             await _context.SaveChangesAsync();
            return medicalHistory;
        }

        public async Task<ActionResult<MedicalHistory>> UpdateMedicalHistoryByUser(MedicalHistory medicalHistory)
        {
            _context.Entry(medicalHistory).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return medicalHistory;
        }

        public async Task<ActionResult<bool>> DeleteMedicalHistoryByUser(int idMedicalHistory)
        {
            try
            {
                var medicalHistory = await _context.MedicalHistory.FindAsync(idMedicalHistory);
                _context.MedicalHistory.Remove(medicalHistory);
                await _context.SaveChangesAsync();
                return true;
            }catch(Exception ex)
            {
                throw new Exception("Record cannot deleted", ex);
            }
        }
    }
}
