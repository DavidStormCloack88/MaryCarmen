using MariaCarmen.Aplicacion.Servicio;
using MariaCarmen.Infraestructura.AccesoDatos;
using Microsoft.AspNetCore.Mvc;

namespace MariaCarmen.Controllers
{
    [ApiController]
    [Route("api/MariaCarmen/[controller]")]
    public class VentaControlador : ControllerBase
    {
        private readonly IVentaServicio _ventaServicio;

        public VentaControlador(IVentaServicio ventaServicio)
        {

            _ventaServicio = ventaServicio;
        }

        // GET: api/categoria
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ventas>>> GetAll()
        {
            var vent = await _ventaServicio.VentaGetAllAsync();
            return Ok(vent);
        }

        //GET: API por id
        [HttpGet("{id}")]
        public async Task<ActionResult<ventas>> GetById(int id)
        {
            var vent = await _ventaServicio.VentaGetByIdAseync(id);
            if (vent == null)
            {
                return NotFound();
            }
            return Ok(vent);
        }

        //Metodo Post para venta
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] ventas vent)
        {
            await _ventaServicio.VentaAddAsync(vent);
            return CreatedAtAction(nameof(GetById), new { id = vent.id_venta }, vent);
        }

        // PUT: api/productos

        [HttpPut("{id}")]
        public async Task<IActionResult> ActualizarVenta(int id, [FromBody] ventas vent)
        {
            if (id != vent.id_venta)
                return BadRequest();

            await _ventaServicio.VentaUpdateAsync(vent);

            return NoContent();
        }

    }
}
