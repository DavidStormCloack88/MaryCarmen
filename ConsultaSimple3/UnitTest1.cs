using MariaCarmen.Aplicacion.Servicio;
using MariaCarmen.Aplicacion.ServicioImpl;
using MariaCarmen.Infraestructura.AccesoDatos;
using Microsoft.EntityFrameworkCore;

namespace ConsultaSimple3
{
    public class Tests
    {
        private IDetalleVentaServicio detalleVentaServicio;
        private MaryCarmenDBContext _MaryCarmenDBContext;
        [SetUp]
        public void Setup()
        {
            var opciones = new DbContextOptionsBuilder<MaryCarmenDBContext>()
                .UseSqlServer("Data Source=DESKTOP-05HME1I;Initial Catalog=MaryCarmenBD;Integrated Security=True;Encrypt=True;TrustServerCertificate=True")
                .Options;
            _MaryCarmenDBContext = new MaryCarmenDBContext(opciones);
            detalleVentaServicio = new DetalleVentaServicioImpl(_MaryCarmenDBContext);
        }

        [Test]
        public async Task Test1()
        {
            var result = await detalleVentaServicio.DetalleVentaGetAllAsync();
            var nombresRoles = result.Select(r => r.cantidad).ToList();
            Console.WriteLine("Listado de fecha por menores a cinco dólares:");
            foreach (var nombre in nombresRoles)
            {
                Console.WriteLine($"- {nombre}");
            }
            //Assert.Pass();
        }
        [TearDown]
        public void DespuesTest()
        {
            _MaryCarmenDBContext.Dispose();
        }
    }
}