using Microsoft.AspNetCore.Mvc;

namespace MariaCarmen.Controllers
{
    [ApiController]
    [Route("api/MaryCarmen/[controller]")]
    public class DemoControlador : ControllerBase
    {
        

        [HttpGet]
        public string mensaje()
        {
            return "Hola Mundo";
        }
        [HttpGet("{nombre}")]
        public string saludos(string nombre)
        {
            return "Hola " + nombre;
        }

        
    }
}
