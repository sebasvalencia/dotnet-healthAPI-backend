using System;
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
        public async Task<ActionResult<MedicalHistory>> GetMedicalHistoryByUserId(int id)
        {
            try
            {
                var createdMedicalHistory = await _medicalHistoryService.GetAllMedicalHistoryById(id);
                if (createdMedicalHistory is null)
                {
                    return new MedicalHistory();
                }
                return Ok(createdMedicalHistory);
            }
            catch (Exception)
            {
                return BadRequest();
            }
            return Ok();
        }

        // POST: api/MedicalHistory
        [HttpPost]
        public async Task<ActionResult<MedicalHistory>> CreateMedicalHistoryByUserId([FromBody] MedicalHistory medicalHistory)
        {
            try
            {
                var createdMedicalHistory = await _medicalHistoryService.CreateMedicalHistoryByUserId(medicalHistory);
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

        // PUT: api/MedicalHistory/5
        [HttpPut("{idUser}")]
        public async Task<ActionResult<MedicalHistory>> UpdateMedicalHistoryByUserId(int idUser, [FromBody] MedicalHistory medicalHistory)
        {
            try
            {
                var updatedMedicalHistory = await _medicalHistoryService.UpdateMedicalHistoryByUserId(idUser, medicalHistory);
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
        [HttpDelete("{id}")]
        public async Task<ActionResult<User>> DeleteMedicalHistoryByUserId(int id)
        {
            try
            {
                var medicalHistory = await _medicalHistoryService.DeleteMedicalHistoryByUserId(id);
                if (medicalHistory is null)
                {
                    return NotFound();
                }
                return Ok(medicalHistory);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}
