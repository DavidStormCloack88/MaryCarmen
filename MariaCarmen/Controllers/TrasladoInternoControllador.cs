using MariaCarmen.Aplicacion.Servicio;
using MariaCarmen.Infraestructura.AccesoDatos;
using Microsoft.AspNetCore.Mvc;

namespace MariaCarmen.Controllers
{
    [ApiController]
    [Route("api/MariaCarmen/[controller]")]
    public class TrasladoInternoControllador : ControllerBase
    {
        private readonly ITrasladoInternoServicio _trasladoInternoServicio;

        public TrasladoInternoControllador(ITrasladoInternoServicio trasladoInternoServicio)
        {
            _trasladoInternoServicio = trasladoInternoServicio;   
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var detalletras = await _trasladoInternoServicio.TrasladoInternoGetAllAsync();
            return Ok(detalletras);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var detalletras = await _trasladoInternoServicio.TrasladoInternoGetByIdAseync(id);
            if (detalletras == null) return NotFound();
            return Ok(detalletras);
        }

        [HttpPost("CrearTrasladoInterno")]
        public async Task<IActionResult> TrasladoInterno([FromBody] traslados_internos traslado_inter)
        {
            try
            {
                await _trasladoInternoServicio.TrasladoInternoAddAsync(traslado_inter);
                return Ok();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                return StatusCode(500, "Error interno");
            }

        }

        // PUT: api/productos

        [HttpPut("{id}")]
        public async Task<IActionResult> ActualizarTraslado(int id, [FromBody] traslados_internos traslado_inter)
        {
            if (id != traslado_inter.id_traslado)
                return BadRequest();

            await _trasladoInternoServicio.TrasladoInternoUpdateAsync(traslado_inter);

            return NoContent();
        }
    }
    
}
