using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
        public async Task<ActionResult<IEnumerable>> GetUsers()
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
        public async Task<ActionResult<User>> CreateUser([FromBody]User user)
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
        [HttpPut("{id}")]
        public async Task<ActionResult<User>> UpdateUser(int id, [FromBody] User user)
        {
            try
            {
                var updateUser = await _usersService.UpdateUser(id, user);
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
        [HttpDelete("{id}")]
        public async Task<ActionResult<User>> DeleteUser(int id)
        {
            try
            {
                var user = await _usersService.DeleteUser(id);
                if (user is null)
                {
                    return NotFound();
                }
                return Ok(user);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}
