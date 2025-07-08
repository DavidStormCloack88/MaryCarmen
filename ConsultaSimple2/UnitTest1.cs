using MariaCarmen.Aplicacion.Servicio;
using MariaCarmen.Aplicacion.ServicioImpl;
using MariaCarmen.Infraestructura.AccesoDatos;
using Microsoft.EntityFrameworkCore;

namespace ConsultaSimple2
{
    public class Tests
    {
        private IVentaServicio ventaServicio;
        private MaryCarmenDBContext _MaryCarmenDBContext;
        [SetUp]
        public void Setup()
        {
            var opciones = new DbContextOptionsBuilder<MaryCarmenDBContext>()
                .UseSqlServer("Data Source=DESKTOP-05HME1I;Initial Catalog=MaryCarmenBD;Integrated Security=True;Encrypt=True;TrustServerCertificate=True")
                .Options;
            _MaryCarmenDBContext = new MaryCarmenDBContext(opciones);
            ventaServicio = new VentaServicioImpl(_MaryCarmenDBContext);
        }

        [Test]
        public async Task Test1()
        {
            var result = await ventaServicio.VentaGetAllAsync();
            var nombresRoles = result.Select(r => r.fecha_hora_venta).ToList();
            Console.WriteLine("Listado de fecha por venta en orden ascendeten:");
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