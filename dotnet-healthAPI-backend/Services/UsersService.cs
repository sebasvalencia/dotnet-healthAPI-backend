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
            var patients = await _context.Users.Where(c => c.Rol == 2).Select(x => UserToDTO(x)).ToListAsync();
            return patients;
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
