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
    public class GastosController : Controller
    {
       private IGastoService gastoService;

        public GastosController(IGastoService gastoService)
        {
            this.gastoService = gastoService;
        }

        [HttpGet]
        public ActionResult Get()
        {
            return Ok(
                gastoService.GetAll()
            );
        }
        [HttpGet("{id}")]
        public ActionResult GetById(int id)
        {
            return Ok(
                gastoService.Get(id)
            );
        }
        [HttpGet("GetAllGastosInicialesByUserId/{id}")]
        public ActionResult GetAllGastosInicialesByUserId(int id)
        {
            return Ok(
                gastoService.GetAllGastosInicialesByUserId(id)
            );
        }
        [HttpGet("GetAllGastosFinalesByUserId/{id}")]
        public ActionResult GetAllGastosFinalesByUserId(int id)
        {
            return Ok(
                gastoService.GetAllGastosFinalesByUserId(id)
            );
        }
        [HttpPost]
        public ActionResult Post([FromBody] Gasto gasto)
        {
            return Ok(
               gastoService.Save(gasto)
            );
        }
        [HttpPut]
        public ActionResult Put([FromBody] Gasto gasto)
        {
            return Ok(
                gastoService.Update(gasto)
            );
        }
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            return Ok(
                gastoService.Delete(id)
            );
        }
    }
}
