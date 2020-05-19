
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
    public class ProductosController : ControllerBase
    {
        ProductosRepository repositorio;
        public ProductosController()
        {
            repositorio = new ProductosRepository();
        }
        // GET: api/Leches
        [HttpGet]
        public ActionResult<List<Producto>> Get()
        {
            var todos = repositorio.LeerTodos();
            return todos;
        }

        // GET: api/Leches/5
        [HttpGet("{id}", Name = "Get")]
        public ActionResult<Producto> Get(int id)
        {
            var producto = repositorio.LeerPorId(id);
            if(producto == null){
                return NotFound();
            }
            return producto;
        }

        // POST: api/Leches
        [HttpPost]
        public IActionResult Post([FromBody] Producto model)
        {
            repositorio.Crear(model);

            return Ok();
        }

        // PUT: api/Leches/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Producto model)
        {
            var producto = repositorio.LeerPorId(model.Id);
            if(producto == null){
                return NotFound();
            }
            
            repositorio.Actualizar(model);
            return Ok();
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var producto = repositorio.LeerPorId(id);
            if(producto == null){
                return NotFound();
            }
            repositorio.Borrar(id);
            return Ok();
        }
    }
}
