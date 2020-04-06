using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dotnet_healthAPI_backend.DTO;
using dotnet_healthAPI_backend.Models;
using dotnet_healthAPI_backend.Services;
using dotnet_healthAPI_backend.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace dotnet_healthAPI_backend.Controllers
{


    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUsersService _usersService;

        public UserController(IUsersService usersService)
        {
            _usersService = usersService;
        }

        // GET: api/User
        [HttpGet]
        public async Task<ActionResult<IEnumerable>> GetAllPatientsWithSickness()
        {
            try
            {
                return Ok(await _usersService.GetAllPatientsWithSickness());
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        // GET: api/User
        [Route("patients")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable>> GetAllPatients()
        {
            try
            {
                return Ok(await _usersService.GetAllPatients());
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        // GET: api/User/5
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUserById(int id)
        {
            try
            {
                return Ok(await _usersService.GetPatientById(id));
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        // POST: api/User
        [HttpPost]
        public async Task<ActionResult<UserDTO>> CreateUser([FromBody]User user)
        {
            try
            {
                return Ok( await _usersService.CreateUser(user));
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        // PUT: api/User/5
        [HttpPut]
        public async Task<ActionResult<UserDTO>> UpdateUser([FromBody] User user)
        {
            try
            {
                var updateUser = await _usersService.UpdateUser(user);
                if (updateUser is null)
                {
                    return NotFound();
                }
                return Ok(updateUser);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        // DELETE: api/User/5
        [HttpDelete]
        public async Task<ActionResult<bool>> DeleteUser(User user)
        {
            try
            {
                var userDelete = await _usersService.DeleteUser(user);
                return Ok(userDelete);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        // POST: api/User/login
        [Route("login")]
        [HttpPost]
        public async Task<ActionResult<bool>> LoginUser([FromBody]Credentials credentials)
        {
            try
            {
                return Ok(await _usersService.LoginUser(credentials));
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}
