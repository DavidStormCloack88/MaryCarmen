using MariaCarmen.Aplicacion.Servicio;
using MariaCarmen.Infraestructura.AccesoDatos;
using Microsoft.AspNetCore.Mvc;

namespace MariaCarmen.Controllers
{
    [ApiController]
    [Route("api/MariaCarmen/[controller]")]
    public class UsuariosControlador : ControllerBase
    {
        private readonly IUsuarioServicio _usuarioServicio;

        public UsuariosControlador(IUsuarioServicio usuarioServicio)
        {
            _usuarioServicio = usuarioServicio;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var usu = await _usuarioServicio.UsuarioGetAllAsync();
            return Ok(usu);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<usuarios>> GetById(int id)
        {
            var usu = await _usuarioServicio.UsuarioGetByIdAseync(id);
            if (usu == null)
            {
                return NotFound();
            }
            return Ok(usu);
        }

        //Metodo Post para usuarios
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] usuarios usu)
        {
            await _usuarioServicio.UsuarioAddAsync(usu);
            return CreatedAtAction(nameof(GetById), new { id = usu.id_usuario }, usu);
        }

        // PUT: api/productos

        [HttpPut("{id}")]
        public async Task<IActionResult> ActualizarUsuarios(int id, [FromBody] usuarios usu)
        {
            if (id != usu.id_usuario)
                return BadRequest();

            await _usuarioServicio.UsuarioUpdateAsync(usu);

            return NoContent();
        }
    }
}
