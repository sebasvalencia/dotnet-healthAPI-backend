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


        public async Task<ActionResult<List<UserSickness>>> CreateUserSickness(List<UserSickness> userSickness)
        {
            foreach (var us in userSickness)
            {
                _context.UserSickness.Add(us);
                await _context.SaveChangesAsync();
            }
            return userSickness;           
        }

        public async Task<ActionResult<List<UserSickness>>> UpdateUserSickness(List<UserSickness> userSickness)
        {
            foreach(var us in userSickness)
            {
                var existingUserSickness = await _context.UserSickness.FirstAsync(a => a.Id == us.Id);
                if (existingUserSickness != null)
                {
                    _context.Entry(existingUserSickness).CurrentValues.SetValues(us);
                    await _context.SaveChangesAsync();
                }
                //_context.Entry(us).State = EntityState.Modified;
                //await _context.SaveChangesAsync();
            }
            return userSickness;

            
        }

        public async Task<ActionResult<UserSickness>> DeleteUserSickness(int IdUserSickness)
        {
            var userSickness = await _context.UserSickness.FindAsync(IdUserSickness);
            if (userSickness == null)
            {
                return new UserSickness();
            }
            _context.UserSickness.Remove(userSickness);
            await _context.SaveChangesAsync();
            return userSickness;
        }

    }
}
