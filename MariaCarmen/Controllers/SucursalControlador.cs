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
    }
    
}
