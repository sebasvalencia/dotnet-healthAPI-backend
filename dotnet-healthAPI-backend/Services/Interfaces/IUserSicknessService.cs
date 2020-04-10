using dotnet_healthAPI_backend.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotnet_healthAPI_backend.Services.Interfaces
{
    public interface IUserSicknessService
    {
        Task<ActionResult<IEnumerable>> GetAllPatientSickness();
        Task<ActionResult<IEnumerable>> GetAllSicknessByPatient(int idPatient);
        Task<ActionResult<UserSickness>> CreateUserSickness(UserSickness userSickness);
        Task<ActionResult<UserSickness>> UpdateUserSickness(UserSickness userSickness);
        Task<ActionResult<UserSickness>> DeleteUserSickness(UserSickness userSickness);
        Task<ActionResult<IEnumerable>> GetPatientSickness(int idPatient);

    }
}
