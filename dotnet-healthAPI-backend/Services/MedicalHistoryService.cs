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
    }
}
