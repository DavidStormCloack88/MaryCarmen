using MariaCarmen.Aplicacion.Servicio;
using MariaCarmen.Infraestructura.AccesoDatos;
using Microsoft.AspNetCore.Mvc;

namespace MariaCarmen.Controllers
{
    [ApiController]
    [Route("api/MariaCarmen/[controller]")]
    public class ProductoControlador : ControllerBase
    {
        private IProductoServicio _productoServicio;

        public ProductoControlador(IProductoServicio productoServicio)
        {
            _productoServicio = productoServicio;
        }

        [HttpGet]
        public Task<IEnumerable<productos>> ProductoGetAllAsync()
        {
            return _productoServicio.ProductoGetAllAsync();
        }

        // GET: api/productos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<productos>> GetById(int id)
        {
            var producto = await _productoServicio.ProductoGetByIdAsync(id);
            if (producto == null)
            {
                return NotFound();
            }
            return Ok(producto);
        }

    }
}
