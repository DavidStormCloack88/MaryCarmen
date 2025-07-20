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
        // POST: api/productos/CrearProducto
        [HttpPost("CrearProducto")]
        public async Task<IActionResult> CrearProducto([FromBody] productos nuevo)
        {
            try
            {
                await _productoServicio.ProductoAddAsync(nuevo);
                return Ok("Producto creado correctamente.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                return StatusCode(500, "Error interno al crear el producto.");
            }
        }

        // PUT: api/productos
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] productos producto)
        {
            try
            {
                var productoExistente = await _productoServicio.ProductoGetByIdAsync(producto.id_producto);
                if (productoExistente == null)
                {
                    return NotFound("Producto no encontrado.");
                }

                // Actualizar propiedades
                productoExistente.nombre_producto = producto.nombre_producto;
                productoExistente.descripcion = producto.descripcion;
                productoExistente.precio_referencia = producto.precio_referencia;
                productoExistente.codigo_producto = producto.codigo_producto;
                productoExistente.categoria = producto.categoria;
                productoExistente.id_categoria = producto.id_categoria;

                await _productoServicio.ProductoUpdateAsync(productoExistente);
                return NoContent(); // 204
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                return StatusCode(500, "Error al actualizar el producto.");
            }
        }



    }
}
