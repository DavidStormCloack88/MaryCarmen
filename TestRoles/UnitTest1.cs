using MariaCarmen.Aplicacion.Servicio;
using MariaCarmen.Aplicacion.ServicioImpl;
using MariaCarmen.Infraestructura.AccesoDatos;
using Microsoft.EntityFrameworkCore;


namespace TestRoles
{
    public class Tests
    {
        private IRolesServicio _rolesServicio;
        private MaryCarmenDBContext _MaryCarmenDBContext;
        [SetUp]
        public void Setup()
        {
            {
                var opciones = new DbContextOptionsBuilder<MaryCarmenDBContext>()
                .UseSqlServer("Data Source=PROGRAMADOR;Initial Catalog=MaryCarmenBD;Integrated Security=True;TrustServerCertificate=True")
                .Options;
                _MaryCarmenDBContext = new MaryCarmenDBContext(opciones);
                _rolesServicio = new RolesServicioImpl(_MaryCarmenDBContext);
            }
        }

        [Test]
        public async Task Test1()
        {
            var rol = new roles
            {
                nombre_rol = "empleado2",
                descripcion = "empleado de planta",

            };
            await _rolesServicio.RolesAddAsync(rol);
            //Assert.Pass();
        }

        [TearDown]
        public void DespuesTest()
        {
            _MaryCarmenDBContext.Dispose();
        }
    }
}