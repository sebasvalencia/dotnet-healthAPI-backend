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
    public class UserSicknessService : IUserSicknessService
    {
        private readonly HealthAPIContext _context;
        public UserSicknessService(HealthAPIContext context)
        {
            _context = context;
        }

        public async Task<ActionResult<IEnumerable>> GetAllPatientSickness()
        {
            return await _context.UserSickness.ToListAsync();
        }

        public async Task<ActionResult<IEnumerable>> GetAllSicknessByPatient(int idPatient)
        {
            return await _context.UserSickness.Where(c => c.UserId == idPatient).ToListAsync();
        }


        public async Task<ActionResult<UserSickness>> CreateUserSickness(UserSickness userSickness)
        {
                _context.UserSickness.Add(userSickness);
                await _context.SaveChangesAsync();
            return userSickness;           
        }

        public async Task<ActionResult<UserSickness>> UpdateUserSickness(UserSickness userSickness)
        {
            _context.Entry(userSickness).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return userSickness;
        }

        public async Task<ActionResult<UserSickness>> DeleteUserSickness(UserSickness userSickness)
        {
            var usToDelete = await _context.UserSickness.FindAsync(userSickness.Id);
            _context.UserSickness.Remove(usToDelete);
            await _context.SaveChangesAsync();
            return usToDelete;
        }

        public async Task<ActionResult<IEnumerable>> GetPatientSickness(int idPatient)
        {
            var allPatientSicknessById = await (from us in _context.UserSickness
                                                join s in _context.Sickness on us.SicknessId equals s.Id
                                                where us.UserId == idPatient
                                                select new
                                                {
                                                    us.Id,
                                                    us.UserId,
                                                    us.SicknessId,
                                                    s.Name,
                                                    s.ScientificNotation,
                                                    s.Description,
                                                    s.ImageUrl
                                                }).ToListAsync();

   

            return allPatientSicknessById;
        }
    }
}
