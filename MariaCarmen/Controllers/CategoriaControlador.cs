using MariaCarmen.Aplicacion.Servicio;
using MariaCarmen.Dominio.Modelos.Abstracciones;
using MariaCarmen.Infraestructura.AccesoDatos;
using Microsoft.AspNetCore.Mvc;

namespace MariaCarmen.Controllers
{
    [ApiController]
    [Route("api/MariaCarmen/[controller]")]
    public class CategoriaControlador : ControllerBase
    {
        private readonly ICategoriaServicio _categoriaServicio;

        public CategoriaControlador(ICategoriaServicio categoriaServicio)
        {

            _categoriaServicio = categoriaServicio;
        }

        // GET: api/categoria
        [HttpGet]
        public async Task<ActionResult<IEnumerable<categoria>>> GetAll()
        {
            var categorias = await _categoriaServicio.CategoriaGetAllAsync();
            return Ok(categorias);
        }

        // GET: api/categoria/5
        [HttpGet("{id}")]
        public async Task<ActionResult<categoria>> GetById(int id)
        {
            var categoria = await _categoriaServicio.CategoriaGetByIdAseync(id);
            if (categoria == null)
            {
                return NotFound();
            }
            return Ok(categoria);
        }

        // POST: api/categoria
        [HttpPost("CrearCategoria")]
        public async Task<IActionResult> CrearProducto([FromBody] categoria nuevoproducto)
        {
            try
            {
                await _categoriaServicio.CategoriaAddAsync(nuevoproducto);
                return Ok();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                return StatusCode(500, "Error interno");
            }

        }

        // PUT: api/categoria/5
        // 'tipo' es opcional
        [HttpPut]
        public async Task<IActionResult> ActualizarCategoria(int id, [FromBody] categoria cat)
        {
            if (id != cat.id_categoria)
                return BadRequest();

            await _categoriaServicio.CategoriaUpdateAsync(cat);

            return NoContent();
        }

        // DELETE: api/categoria/5
        [HttpDelete("{id}")]
        
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _categoriaServicio.CategoriaDeleteAsync(id);
                return NoContent(); // 204 OK
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al eliminar: {ex.Message}");
            }
        }



        /*[HttpPut("actulizar categoria")]

        public async Task<IActionResult> ActualizarCategoria([FromBody] categoria actuliazarcategoria)
        {
            try
            {
                await _categoriaServicio.CategoriaUpdateAsync(actuliazarcategoria);
                return Ok();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                return StatusCode(500, "Error interno");
            }
        }*/


    }
}
