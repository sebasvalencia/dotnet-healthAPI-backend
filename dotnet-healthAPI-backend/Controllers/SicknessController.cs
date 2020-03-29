using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dotnet_healthAPI_backend.Models;
using dotnet_healthAPI_backend.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace dotnet_healthAPI_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SicknessController : ControllerBase
    {
        private readonly ISicknessService _sicknessService;

        public SicknessController(ISicknessService sicknessService)
        {
            _sicknessService = sicknessService;
        }
        // GET: api/Sickness
        [HttpGet]
        public async Task<ActionResult<IEnumerable>> GetAllSickness()
        {
            return Ok(await _sicknessService.GetAllSickness());
        }

        // GET: api/Sickness/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Sickness>> GetSicknessById(int id)
        {
            return Ok(await _sicknessService.GetSicknessById(id));
        }

        // POST: api/Sickness
        [HttpPost]
        public async Task<ActionResult<Sickness>> CreateSickness([FromBody] Sickness sickness)
        {
            return Ok(await _sicknessService.CreateSickness(sickness));
        }

        // PUT: api/Sickness/5
        [HttpPut("{id}")]
        public async Task<ActionResult<User>> UpdateSickness(int id, [FromBody] Sickness sickness)
        {
            return Ok(await _sicknessService.UpdateSickness(id, sickness));
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Sickness>> DeleteSickness(int id)
        {
            return Ok(await _sicknessService.DeleteSickness(id));
        }
    }
}
