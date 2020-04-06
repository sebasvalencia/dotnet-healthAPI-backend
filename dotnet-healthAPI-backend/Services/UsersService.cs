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
        
        public async Task<ActionResult<IEnumerable>> GetAllPatientsWithSickness()
        {
            var infoPatient = new List<UserDTO>();

            var allPatients = await(from u in _context.Users
                          join us in _context.UserSickness on u.Id equals us.UserId
                          join s in _context.Sickness on us.SicknessId equals s.Id
                          where u.Rol == 2
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

        public async Task<ActionResult<IEnumerable>> GetAllPatients()
        {
            return await _context.Users.Where(c => c.Rol == 2).Select(x => UserToDTO(x)).ToListAsync();
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

        public async Task<ActionResult<UserDTO>> CreateUser(User user)
        {
            _context.Users.Add(user);
             await _context.SaveChangesAsync();
             return UserToDTO(user);
        }

        public async Task<ActionResult<UserDTO>> UpdateUser( User user)
        {
            _context.Entry(user).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return UserToDTO(user);
        }

        public async Task<ActionResult<bool>> DeleteUser(User user)
        {
            try
            {
                _context.Users.Remove(user);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("Record cannot deleted", ex);
            }
        }

        public async Task<ActionResult<bool>> LoginUser(Credentials credentials)
        {
            var userEmail = await _context.Users.Where(x => x.Email == credentials.Email && x.Rol == 1).ToListAsync();
            var userPassword = await _context.Users.Where(x => x.Password == credentials.Password && x.Rol == 1).ToListAsync();

            return (userEmail.Count > 0 && userPassword.Count > 0) ? true : false; 
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
