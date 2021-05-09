using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MockDBExample.Models;
using MockDBExample.Services.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MockDBExample.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IUserService userService;
        public UserController(IUserService _userService)
        {
            userService = _userService;
        }

        [HttpGet("{uid}")]
        public ActionResult<User> GetUser(string uid)
        {
            return Ok(userService.GetUser(uid));
        }

        [HttpGet("list")]
        public ActionResult<IEnumerable<User>> GetUserList()
        {
            return Ok(userService.GetUserList());
        }

        [HttpPost]
        public ActionResult AddUser([FromBody] User user)
        {
            userService.AddUser(user);
            return Ok();
        }
    }
}
