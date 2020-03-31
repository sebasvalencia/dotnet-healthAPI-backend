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

        public async Task<ActionResult<MedicalHistory>> CreateMedicalHistoryByUserId(MedicalHistory medicalHistory)
        {
            _context.MedicalHistory.Add(medicalHistory);
            await _context.SaveChangesAsync();

            return medicalHistory;
        }

        public async Task<ActionResult<MedicalHistory>> UpdateMedicalHistoryByUserId(int idUser, MedicalHistory medicalHistory)
        {
            if (idUser != medicalHistory.UserId)
            {
                return new MedicalHistory();
            }

            _context.Entry(medicalHistory).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return medicalHistory;
        }

        public async Task<ActionResult<MedicalHistory>> DeleteMedicalHistoryByUserId(int id)
        {
            var medicalHistory = await _context.MedicalHistory.FindAsync(id);
            if (medicalHistory  == null)
            {
                return new MedicalHistory();
            }
            _context.MedicalHistory.Remove(medicalHistory);
            await _context.SaveChangesAsync();
            return medicalHistory;
        }
    }
}
