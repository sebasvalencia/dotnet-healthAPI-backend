using dotnet_healthAPI_backend.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotnet_healthAPI_backend.Services.Interfaces
{
    public interface ISicknessService
    {
        Task<ActionResult<IEnumerable>> GetAllSickness();
        Task<ActionResult<Sickness>> GetSicknessById(int id);
        Task<ActionResult<Sickness>> CreateSickness(Sickness sickness);
        Task<ActionResult<Sickness>> UpdateSickness(int id, Sickness sickness);
        Task<ActionResult<Sickness>> DeleteSickness(int id);
    }
}
