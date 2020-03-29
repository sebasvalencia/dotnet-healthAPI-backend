using dotnet_healthAPI_backend.Data;
using dotnet_healthAPI_backend.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections;
using System.Threading.Tasks;

namespace dotnet_healthAPI_backend.Services
{
    public class UsersService : IUsersService
    {
        private readonly HealthAPIContext _context;
        public UsersService(HealthAPIContext context)
        {
            _context = context;
        }
        
        public async Task<ActionResult<IEnumerable>> GetAllUsersService()
        {
            return  await _context.Users.ToListAsync();
        }

        
    }
}
