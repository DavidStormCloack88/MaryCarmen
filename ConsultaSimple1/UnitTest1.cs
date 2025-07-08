using MariaCarmen.Aplicacion.Servicio;
using MariaCarmen.Aplicacion.ServicioImpl;
using MariaCarmen.Infraestructura.AccesoDatos;
using Microsoft.EntityFrameworkCore;

namespace ConsultaSimple1
{
    public class Tests
    {
        private IVentaServicio _ventaServicio;
        private MaryCarmenDBContext _MaryCarmenDBContext;
        [SetUp]
        public void Setup()
        {
            var opciones = new DbContextOptionsBuilder<MaryCarmenDBContext>()
                .UseSqlServer("Data Source=DESKTOP-05HME1I;Initial Catalog=MaryCarmenBD;Integrated Security=True;Encrypt=True;TrustServerCertificate=True")
                .Options;
            _MaryCarmenDBContext = new MaryCarmenDBContext(opciones);
            _ventaServicio = new VentaServicioImpl(_MaryCarmenDBContext);
        }

        [Test]
        public async Task Test1()
        {

            var result = await _ventaServicio.ListaPorFecha();
            foreach (var item in result)
            {
                Console.WriteLine(item.idTipo + "-" + item.ProductoVentaFec);
                foreach (var item2 in item.NombresProductosFec)
                {
                    Console.WriteLine(item2);
                }
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