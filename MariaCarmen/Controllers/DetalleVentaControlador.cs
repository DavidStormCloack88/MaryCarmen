using MariaCarmen.Aplicacion.Servicio;
using MariaCarmen.Infraestructura.AccesoDatos;
using Microsoft.AspNetCore.Mvc;

namespace MariaCarmen.Controllers
{
    [ApiController]
    [Route("api/MariaCarmen/[controller]")]
    public class DetalleVentaControlador : ControllerBase
    {
        public readonly IDetalleVentaServicio _detalleVentaServicio;

        public DetalleVentaControlador(IDetalleVentaServicio _detalle_venta) 
        {
            _detalleVentaServicio = _detalle_venta;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var det_ven = await _detalleVentaServicio.DetalleVentaGetAllAsync();
            return Ok(det_ven);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var det_ven = await _detalleVentaServicio.DetalleVentaGetByIdAseync(id);
            if (det_ven == null) return NotFound();
            return Ok(det_ven);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] detalle_venta vent_detal)
        {
            await _detalleVentaServicio.DetalleVentaAddAsync(vent_detal);
            return CreatedAtAction(nameof(GetById), new { id = vent_detal.id_detalle_venta }, vent_detal);
        }

        // PUT: api/roles

        [HttpPut("{ActualizarRol}")]
        public async Task<IActionResult> ActualizarDetalleVenta(int id, [FromBody] detalle_venta vent_detal)
        {
            if (id != vent_detal.id_detalle_venta)
                return BadRequest();

            await _detalleVentaServicio.DetalleVentaUpdateAsync(vent_detal);

            return NoContent();
        }
    }
  
    
}
