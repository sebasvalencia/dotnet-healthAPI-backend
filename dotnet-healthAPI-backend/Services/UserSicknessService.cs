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

            return await (from us in _context.UserSickness
                          join u in _context.Users on us.UserId equals u.Id
                          join s in _context.Sickness on us.SicknessId equals s.Id
                          select new
                          {
                              IdUser = us.UserId,
                              NameUser = u.Name,
                              IdSickness = s.Id,
                              NameSickness = s.Name
                          }).ToListAsync();
        }

        public async Task<ActionResult<IEnumerable>> GetAllSicknessByPatient(int idPatient)
        {

            return await (from us in _context.UserSickness
                          join u in _context.Users on us.UserId equals u.Id
                          join s in _context.Sickness on us.SicknessId equals s.Id
                          where us.UserId == idPatient
                          select new
                          {
                              IdUser = us.UserId,
                              NameUser = u.Name,
                              IdSickness = s.Id,
                              NameSickness = s.Name
                          }).ToListAsync();
        }


        public async Task<ActionResult<List<UserSickness>>> CreatePatientSickness(List<UserSickness> userSickness)
        {
            foreach(UserSickness us in userSickness)
            {
                var user = await _context.Users.SingleOrDefaultAsync(user => user.Id == us.UserId);
                var sick = await _context.Sickness.SingleOrDefaultAsync(sick => sick.Id == us.SicknessId);

                if (user != null && sick != null)
                {
                    _context.UserSickness.Add(us);
                    await _context.SaveChangesAsync();

                }
            }
            
            return userSickness;
            
        }
    }
}
