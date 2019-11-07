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
    public class LetrasController : Controller
    {
       private ILetraService letraService;

        public LetrasController(ILetraService letraService)
        {
            this.letraService = letraService;
        }

        [HttpGet]
        public ActionResult Get()
        {
            return Ok(
                letraService.GetAll()
            );
        }
        [HttpGet("{id}")]
        public ActionResult GetById(int id)
        {
            return Ok(
                letraService.Get(id)
            );
        }
        [HttpGet("GetLetrasByUserId/{id}")]
        public ActionResult GetLetrasByUserId(int id)
        {
            return Ok(
                letraService.GetLetrasByUserId(id)
            );
        }
        [HttpPost]
        public ActionResult Post([FromBody] Letra letra)
        {
            return Ok(
               letraService.Save(letra)
            );
        }
        [HttpPut]
        public ActionResult Put([FromBody] Letra letra)
        {
            return Ok(
                letraService.Update(letra)
            );
        }
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            return Ok(
                letraService.Delete(id)
            );
        }
    }
}
