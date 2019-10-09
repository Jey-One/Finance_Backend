using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Finance.Entity;
using Finance.Service;
using Microsoft.AspNetCore.Mvc;

namespace Finance.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : Controller
    {
       private IUserService userService;

        public UsersController(IUserService userService)
        {
            this.userService = userService;
        }

        [HttpGet]
        public ActionResult Get()
        {
            return Ok(
                userService.GetAll()
            );
        }
        [HttpGet("{id}")]
        public ActionResult GetById(int id)
        {
            return Ok(
                userService.Get(id)
            );
        }
        [HttpPost]
        public ActionResult Post([FromBody] User user)
        {
            return Ok(
               userService.Save(user)
            );
        }
        [HttpPut("{id}")]
        public ActionResult Put([FromBody] User user)
        {
            return Ok(
                userService.Update(user)
            );
        }
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            return Ok(
                userService.Delete(id)
            );
        }

        [HttpGet("{username}/{password}")]
        public ActionResult Login(string username, string password)
        {
            return Ok(
                userService.Login(username,password)
            );
        }
    }
}
