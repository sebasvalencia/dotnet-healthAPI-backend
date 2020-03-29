using Microsoft.AspNetCore.Mvc;
using System.Collections;
using System.Threading.Tasks;

namespace dotnet_healthAPI_backend.Services.Interfaces
{
    public interface IUsersService
    {
        Task<ActionResult<IEnumerable>> GetAllUsersService();
    }
}
