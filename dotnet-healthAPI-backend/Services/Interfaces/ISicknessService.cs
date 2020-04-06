using dotnet_healthAPI_backend.DTO;
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
        Task<ActionResult<SicknessDTO>> GetSicknessById(int id);
        Task<ActionResult<SicknessDTO>> CreateSickness(Sickness sickness);
        Task<ActionResult<SicknessDTO>> UpdateSickness(Sickness sickness);
        Task<ActionResult<SicknessDTO>> DeleteSickness(int id);
    }
}
