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

        Task<ActionResult<List<UserSickness>>> CreatePatientSickness(List<UserSickness> userSickness);

        Task<ActionResult<List<UserSickness>>> UpdateUserSickness(List <UserSickness> userSickness);
        Task<ActionResult<UserSickness>> DeleteUserSickness(int idUserSickness); //int idPatient, int idUserSickness

    }
}
