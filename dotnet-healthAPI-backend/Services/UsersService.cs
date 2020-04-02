using dotnet_healthAPI_backend.Data;
using dotnet_healthAPI_backend.Models;
using dotnet_healthAPI_backend.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using System.Collections;
using System.Linq;
using System.Threading.Tasks;
using dotnet_healthAPI_backend.DTO;
using System.Collections.Generic;
using System;

namespace dotnet_healthAPI_backend.Services
{
    public class UsersService : IUsersService
    {
        private readonly HealthAPIContext _context;
        public UsersService(HealthAPIContext context)
        {
            _context = context;
        }
        
        public async Task<ActionResult<IEnumerable>> GetAllPatients()
        {
            var infoPatient = new List<UserDTO>();

            var allPatients = await(from u in _context.Users
                          join us in _context.UserSickness on u.Id equals us.UserId
                          join s in _context.Sickness on us.SicknessId equals s.Id
                          //where u.Rol == 2
                          select new
                          {
                              IdUser = u.Id,
                              NameUser = u.Name,
                              u.AvatarUrl,
                              u.Rol,
                              s.Id,
                              s.Name,
                              s.ScientificNotation,
                              s.Description,
                              s.ImageUrl
                          }).ToListAsync();

            foreach (var item in allPatients)
            {
                var user = new UserDTO(item.IdUser, item.NameUser, item.AvatarUrl, item.Rol);

                if (infoPatient.Where(p => p.Id == user.Id).ToList().Count == 0)
                {
                    var sicks = (from value in allPatients
                                 where value.IdUser == user.Id
                                 select new SicknessDTO
                                 {
                                     Id = value.Id,
                                     Name = value.Name,
                                     ScientificNotation = value.ScientificNotation,
                                     Description = value.Description,
                                     ImageUrl = value.ImageUrl
                                 }).ToList();
                    user.ListSickness = sicks;
                    infoPatient.Add(user);
                }
            }
            return infoPatient;
        }

        public async Task<ActionResult<UserDTO>> GetPatientById(int id)
        {
            var patient = await _context.Users.FindAsync(id);
            if (patient == null)
            {
                return new UserDTO();
            }
            return UserToDTO(patient);
        }

        public async Task<ActionResult<User>> CreateUser(User user)
        {
            _context.Users.Add(user);
             await _context.SaveChangesAsync();

             return user;
        }

        public async Task<ActionResult<User>> UpdateUser(int id, User user)
        {
            if (id != user.Id)
            {
                return new User();
            }

            _context.Entry(user).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return user;
        }

        public async Task<ActionResult<User>> DeleteUser(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                return new User();
            }
            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
            return user;
        }

        private static UserDTO UserToDTO(User user) =>
        new UserDTO
        {
            Id = user.Id,
            Name = user.Name,
            Email = user.Email,
            AvatarUrl = user.AvatarUrl,
            Rol = user.Rol
        };

    }
}
