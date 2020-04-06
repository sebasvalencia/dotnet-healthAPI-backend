using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dotnet_healthAPI_backend.DTO;
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
            try
            {
                return Ok(await _sicknessService.GetAllSickness());
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        // GET: api/Sickness/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SicknessDTO>> GetSicknessById(int id)
        {
            try
            {
                return Ok(await _sicknessService.GetSicknessById(id));
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        // POST: api/Sickness
        [HttpPost]
        public async Task<ActionResult<SicknessDTO>> CreateSickness([FromBody] Sickness sickness)
        {
            try
            {
                return Ok(await _sicknessService.CreateSickness(sickness));
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        // PUT: api/Sickness
        [HttpPut]
        public async Task<ActionResult<SicknessDTO>> UpdateSickness([FromBody] Sickness sickness)
        {
            try
            {
                var updateSickness = await _sicknessService.UpdateSickness(sickness);
                if (updateSickness is null)
                {
                    return NotFound();
                }
                return Ok(updateSickness);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        // DELETE: api/Sickness/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<SicknessDTO>> DeleteSickness(int id)
        {
            try
            {
                var deleteSickness = await _sicknessService.DeleteSickness(id);
                if (deleteSickness is null)
                {
                    return NotFound();
                }
                return Ok(deleteSickness);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}
