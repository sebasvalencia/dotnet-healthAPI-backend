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
            return Ok(await _usersService.GetAllUsersService());
        }


        // GET: api/User/5
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUserById(int id)
        {
            return Ok(await _usersService.GetUserServiceById(id));
        }

        // POST: api/User
        [HttpPost]
        public async Task<ActionResult<User>> CreateUser([FromBody]User user)
        {
            return Ok(await _usersService.CreateUser(user));
        }

        //// PUT: api/Users/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE: api/ApiWithActions/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
