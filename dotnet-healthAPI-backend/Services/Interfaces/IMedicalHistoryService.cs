using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotnet_healthAPI_backend.Services.Interfaces
{
    public interface IMedicalHistoryService
    {
        Task<ActionResult<IEnumerable>> GetAllMedicalHistoryById(int idUser);
    }
}
