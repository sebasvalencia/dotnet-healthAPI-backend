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
    public class WellnessController : ControllerBase
    {

        private readonly IWellnessService _wellnessService;

        public WellnessController(IWellnessService wellnessService)
        {
            _wellnessService = wellnessService;
        }

        // GET: api/Wellness/5
        [HttpGet("{userId}")]
        public async Task<ActionResult<IEnumerable>> GetAllWellnessById(int userId)
        {
            try
            {
                var getWellness = await _wellnessService.GetAllWellnessById(userId);

                return Ok(getWellness);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        // POST: api/Wellness
        [HttpPost]
        public async Task<ActionResult<Wellness>> CreateUpdateWellnessByUserId([FromBody] Wellness wellness)
        {
            try
            {
                var createdWellness = await _wellnessService.CreateWellnessByUser(wellness);
                if (createdWellness is null)
                {
                    return NotFound();
                }
                return Ok(createdWellness);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}
