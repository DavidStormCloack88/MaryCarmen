using MariaCarmen.Aplicacion.Servicio;
using MariaCarmen.Aplicacion.ServicioImpl;
using MariaCarmen.Dominio.Modelos.Abstracciones;
using MariaCarmen.Infraestructura.AccesoDatos;
using Microsoft.EntityFrameworkCore;

namespace ConsultaSimple
{
    public class Tests
    {
        private IRolesServicio rolesServicio;
        private MaryCarmenDBContext _MaryCarmenDBContext;
        [SetUp]
        public void Setup()
        {
            var opciones = new DbContextOptionsBuilder<MaryCarmenDBContext>()
                .UseSqlServer("Data Source=DESKTOP-05HME1I;Initial Catalog=MaryCarmenBD;Integrated Security=True;Encrypt=True;TrustServerCertificate=True")
                .Options;
            _MaryCarmenDBContext = new MaryCarmenDBContext(opciones);
            rolesServicio = new RolesServicioImpl(_MaryCarmenDBContext);
        }

        [Test]
        public async Task Test1()
        {
            //await rolesServicio.RolesGetAllAsync();
            var result = await rolesServicio.RolesGetAllAsync();
            var nombresRoles = result.Select(r => r.nombre_rol).ToList();
            Console.WriteLine("Listado de roles:");
            foreach (var nombre in nombresRoles)
            {
                Console.WriteLine($"- {nombre}");
            }
            //
            //var result = rolesServicio.ListarolEmpleado();
            //Console.WriteLine(result);
        }

        [TearDown]
        public void DespuesTest()
        {
            _MaryCarmenDBContext.Dispose();
        }
    }
}