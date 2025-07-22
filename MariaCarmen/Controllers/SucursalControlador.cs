using MariaCarmen.Aplicacion.Servicio;
using MariaCarmen.Infraestructura.AccesoDatos;
using Microsoft.AspNetCore.Mvc;

namespace MariaCarmen.Controllers
{
    [ApiController]
    [Route("api/MariaCarmen/[controller]")]
    public class SucursalControlador : ControllerBase
    {
        private readonly ISucursalesServicio _sucucesalesServicio;
        
        public SucursalControlador(ISucursalesServicio sucucesalesServicio) 
        {
            _sucucesalesServicio = sucucesalesServicio;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<sucursales>>> GetAll()
        {
            var sucursal = await _sucucesalesServicio.SucursalesGetAllAsync();
            return Ok(sucursal);
        }

        // GET: api/sucursales
        [HttpGet("{id}")]
        public async Task<ActionResult<sucursales>> GetById(int id)
        {
            var sucursal = await _sucucesalesServicio.SucursalesGetByIdAseync(id);
            if (sucursal == null)
            {
                return NotFound();
            }
            return Ok(sucursal);
        }

        [HttpPost("CrearSucursal")]
        public async Task<IActionResult> CrearSucursal([FromBody] sucursales sucursal)
        {
            try
            {
                await _sucucesalesServicio.SucursalesAddAsync(sucursal);
                return Ok("Sucursal creada correctamente.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                return StatusCode(500, "Error interno al crear el producto.");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> ActualizarSucursal(int id, [FromBody] sucursales sucursal)
        {
            if (id != sucursal.id_sucursal)
                return BadRequest();

            await _sucucesalesServicio.SucursalesUpdateAsync(sucursal);

            return NoContent();
        }
    }
    
}
