using dotnet_healthAPI_backend.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotnet_healthAPI_backend.Services.Interfaces
{
    public interface IWellnessService
    {
        Task<ActionResult<IEnumerable>> GetAllWellnessById(int idUser);
        Task<ActionResult<Wellness>> CreateWellnessByUser(Wellness medicalHistory);
    }
}
