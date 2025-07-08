using MariaCarmen.Aplicacion.Servicio;
using MariaCarmen.Aplicacion.ServicioImpl;
using MariaCarmen.Dominio.Modelos.Abstracciones;
using MariaCarmen.Infraestructura.AccesoDatos;
using Microsoft.EntityFrameworkCore;

namespace ConsultaCompuesta6
{
    public class Tests
    {
        private ISucursalesServicio _sucursalesServicio;
        private MaryCarmenDBContext _MaryCarmenDBContext;
        [SetUp]
        public void Setup()
        {
            var opciones = new DbContextOptionsBuilder<MaryCarmenDBContext>()
                .UseSqlServer("Data Source=DESKTOP-05HME1I;Initial Catalog=MaryCarmenBD;Integrated Security=True;Encrypt=True;TrustServerCertificate=True")
                .Options;
            _MaryCarmenDBContext = new MaryCarmenDBContext(opciones);
            _sucursalesServicio = new SucursalesServicioImpl(_MaryCarmenDBContext);
        }

        [Test]
        public async Task Test1()
        {
            var result = await _sucursalesServicio.ListarporSucursal();
            foreach (var item in result)
            {
                Console.WriteLine(item.idTipo + "-" + item.Recuperar);
                foreach (var item2 in item.Datos)
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