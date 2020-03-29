using dotnet_healthAPI_backend.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections;
using System.Threading.Tasks;

namespace dotnet_healthAPI_backend.Services.Interfaces
{
    public interface IUsersService
    {
        Task<ActionResult<IEnumerable>> GetAllUsersService();
        Task<ActionResult<User>> GetUserServiceById(int id);
        Task<ActionResult<User>> CreateUser(User user);
        Task<ActionResult<User>> UpdateUser(int id, User user);
    }
}
