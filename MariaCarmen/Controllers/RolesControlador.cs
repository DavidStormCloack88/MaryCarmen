using MariaCarmen.Aplicacion.Servicio;
using MariaCarmen.Dominio.Modelos.Abstracciones;
using MariaCarmen.Infraestructura.AccesoDatos;
using Microsoft.AspNetCore.Mvc;

namespace MariaCarmen.Controllers
{
    [ApiController]
    [Route("api/MariaCarmen/[controller]")]
    public class RolesControlador : ControllerBase
    {
        private readonly IRolesServicio _rolesServicio;

        public RolesControlador(IRolesServicio rolesServicio)
        {
            _rolesServicio = rolesServicio;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var roles = await _rolesServicio.RolesGetAllAsync();
            return Ok(roles);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var rol = await _rolesServicio.RolesGetByIdAseync(id);
            if (rol == null) return NotFound();
            return Ok(rol);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] roles rol)
        {
            await _rolesServicio.RolesAddAsync(rol);
            return CreatedAtAction(nameof(GetById), new { id = rol.id_rol }, rol);
        }   

        // PUT: api/roles

        [HttpPut]
        public async Task<IActionResult> ActualizarRol(int id, [FromBody] roles rol)
        {
            if (id != rol.id_rol)
                return BadRequest();

            await _rolesServicio.RolesUpdateAsync(rol);

            return NoContent();
        }

    }

}
