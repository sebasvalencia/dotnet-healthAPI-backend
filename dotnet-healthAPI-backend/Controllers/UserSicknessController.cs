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
    public class UserSicknessController : ControllerBase
    {
        private readonly IUserSicknessService _userSicknessService;

        public UserSicknessController(IUserSicknessService userSicknessService)
        {
            _userSicknessService = userSicknessService;
        }
        // GET: api/UserSickness
        [HttpGet]
        public async Task<ActionResult<IEnumerable>> GetAllPatientSickness()
        {
            try
            {
                var patientsSickness = await _userSicknessService.GetAllPatientSickness();
                if (patientsSickness is null)
                {
                    return NotFound();
                }
                return Ok(patientsSickness);

            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        // GET: api/UserSickness/5
        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable>> GetAllSicknessByPatient(int id)
        {
            try
            {
                var patientSickness = await _userSicknessService.GetAllSicknessByPatient(id);
                if (patientSickness is null)
                {
                    return NotFound();
                }
                return Ok(patientSickness);

            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        // POST: api/UserSickness
        [HttpPost]
        public async Task<ActionResult<UserSickness>> CreatePatientSickness([FromBody]  List<UserSickness> userSickness)
        {
            try
            {
                var patientSickness = await _userSicknessService.CreatePatientSickness(userSickness);
                if (patientSickness is null)
                {
                    return NotFound();
                }
                return Ok(patientSickness);

            }
            catch (Exception)
            {
                return BadRequest();
            }
        }



        // PUT: api/UserSickness/5
        [HttpPut("{idUser}")]
        public async Task<ActionResult<UserSickness>> UpdateUserSickness(int idUser, [FromBody] List<UserSickness> userSicknesses)
        {
            return Ok(await _userSicknessService.UpdateUserSickness(userSicknesses));
        }

        // DELETE: api/UserSickness/5
        [HttpDelete("{idUserSickness}")]
        public async Task<ActionResult<User>> DeleteUserSickness(int idUserSickness)
        {
            return Ok(await _userSicknessService.DeleteUserSickness(idUserSickness));
        }
    }     
}
