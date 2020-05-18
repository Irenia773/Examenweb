using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ejemplo.Models;

namespace ejemplo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LechesController : ControllerBase
    {
        LechesRepository repositorio;
        public LechesController()
        {
            repositorio = new LechesRepository();
        }
        // GET: api/Leches
        [HttpGet]
        public ActionResult<List<Leche>> Get()
        {
            var todos = repositorio.LeerTodos();
            return todos;
        }

        // GET: api/Leches/5
        [HttpGet("{id}", Name = "Get")]
        public ActionResult<Leche> Get(int id)
        {
            var leche = repositorio.LeerPorId(id);
            if(leche == null){
                return NotFound();
            }
            return leche;
        }

        // POST: api/Leches
        [HttpPost]
        public IActionResult Post([FromBody] Leche model)
        {
            repositorio.Crear(model);

            return Ok();
        }

        // PUT: api/Leches/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Leche model)
        {
            var leche = repositorio.LeerPorId(model.Id);
            if(leche == null){
                return NotFound();
            }
            
            repositorio.Actualizar(model);
            return Ok();
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var leche = repositorio.LeerPorId(id);
            if(leche == null){
                return NotFound();
            }
            repositorio.Borrar(id);
            return Ok();
        }
    }
}
