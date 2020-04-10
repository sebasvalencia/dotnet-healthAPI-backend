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
                return Ok(await _userSicknessService.GetAllPatientSickness());
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        // GET: api/UserSickness/5
        [HttpGet("{idPatient}")]
        public async Task<ActionResult<IEnumerable>> GetPatientSickness(int idPatient)
        {
            try
            {
                return Ok(await _userSicknessService.GetPatientSickness(idPatient));
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        // POST: api/UserSickness
        [HttpPost]
        public async Task<ActionResult<UserSickness>> CreateUserSickness([FromBody]  UserSickness userSickness)
        {
            try
            {
                return Ok (await _userSicknessService.CreateUserSickness(userSickness));
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        // PUT: api/UserSickness/5
        [HttpPut]
        public async Task<ActionResult<UserSickness>> UpdateUserSickness(int idUser, [FromBody] UserSickness userSicknesses)
        {
            try
            {
                var userSickness = await _userSicknessService.UpdateUserSickness(userSicknesses);
                if (userSickness is null)
                {
                    return NotFound();
                }
                return Ok(userSickness);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        // DELETE: api/UserSickness
        [HttpDelete]
        public async Task<ActionResult<User>> DeleteUserSickness([FromBody] UserSickness userSicknesses)
        {
            try
            {
                var userSickness = await _userSicknessService.DeleteUserSickness(userSicknesses);
                if (userSickness is null)
                {
                    return NotFound();
                }
                return Ok(userSickness);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }     
}
