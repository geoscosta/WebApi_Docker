using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Model;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private List<UserModel> users = null;

        public UserController()
        {
            users = new List<UserModel>()
            {
                new UserModel() { Id = 1, Name = "João"},
                new UserModel() { Id = 2, Name = "Maria"}
            };
        }

        public IActionResult GetUsers()
        {
            return Ok(users);
        }

        [Route("{id:int}")]
        public IActionResult GetUserById(int id)
        {
            var user = users.FirstOrDefault(x => x.Id == id);

            if (user == null)
                return NotFound();

            return Ok(user);
        }
    }
}
