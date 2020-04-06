using dotnet_healthAPI_backend.DTO;
using dotnet_healthAPI_backend.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections;
using System.Threading.Tasks;

namespace dotnet_healthAPI_backend.Services.Interfaces
{
    public interface IUsersService
    {
        Task<ActionResult<IEnumerable>> GetAllPatientsWithSickness();
        Task<ActionResult<IEnumerable>> GetAllPatients();
        Task<ActionResult<UserDTO>> GetPatientById(int id);
        Task<ActionResult<UserDTO>> CreateUser(User user);
        Task<ActionResult<UserDTO>> UpdateUser(User user);
        Task<ActionResult<bool>> DeleteUser(User user);
        Task<ActionResult<bool>> LoginUser(Credentials credentials);
    }
}
