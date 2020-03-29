using dotnet_healthAPI_backend.DTO;
using dotnet_healthAPI_backend.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections;
using System.Threading.Tasks;

namespace dotnet_healthAPI_backend.Services.Interfaces
{
    public interface IUsersService
    {
        Task<ActionResult<IEnumerable>> GetAllPatients();
        Task<ActionResult<UserDTO>> GetPatientById(int id);
        Task<ActionResult<User>> CreateUser(User user);
        Task<ActionResult<User>> UpdateUser(int id, User user);
        Task<ActionResult<User>> DeleteUser(int id);
    }
}
