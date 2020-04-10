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
    public class MedicalHistoryController : ControllerBase
    {
        private readonly IMedicalHistoryService _medicalHistoryService;

        public MedicalHistoryController(IMedicalHistoryService medicalHistoryService)
        {
            _medicalHistoryService = medicalHistoryService;
        }

        // GET: api/MedicalHistory/5
        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable>> GetMedicalHistoryByUserId(int id)
        {
            try
            {
                var getMedicalHistory = await _medicalHistoryService.GetAllMedicalHistoryById(id);
              
                return Ok(getMedicalHistory);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        // POST: api/MedicalHistory
        [HttpPost]
        public async Task<ActionResult<MedicalHistory>> CreateMedicalHistoryByUserId([FromBody] MedicalHistory medicalHistory)
        {
            try
            {
                var createdMedicalHistory = await _medicalHistoryService.CreateMedicalHistoryByUser(medicalHistory);
                if (createdMedicalHistory is null)
                {
                    return NotFound();
                }
                return Ok(createdMedicalHistory);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        // PUT: api/MedicalHistory
        [HttpPut]
        public async Task<ActionResult<MedicalHistory>> UpdateMedicalHistoryByUser([FromBody] MedicalHistory medicalHistory)
        {
            try
            {
                var updatedMedicalHistory = await _medicalHistoryService.UpdateMedicalHistoryByUser(medicalHistory);
                if (updatedMedicalHistory is null)
                {
                    return NotFound();
                }
                return Ok(updatedMedicalHistory);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        // DELETE: api/MedicalHistory/5
        [HttpDelete("{idMedicalHistory}")]
        public async Task<ActionResult<bool>> DeleteMedicalHistoryByUser(int idMedicalHistory)
        {
            try
            {
                var deletedMedicalHistory = await _medicalHistoryService.DeleteMedicalHistoryByUser(idMedicalHistory);
                if (deletedMedicalHistory is null)
                {
                    return NotFound();
                }
                return Ok(deletedMedicalHistory);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}
