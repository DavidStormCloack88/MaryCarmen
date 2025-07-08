using MariaCarmen.Aplicacion.Servicio;
using MariaCarmen.Aplicacion.ServicioImpl;
using MariaCarmen.Infraestructura.AccesoDatos;
using Microsoft.EntityFrameworkCore;

namespace ConsultaCompuesta3
{
    public class Tests
    {
        private IUsuarioServicio _usuarioServicio;
        private MaryCarmenDBContext _MaryCarmenDBContext;
        [SetUp]
        public void Setup()
        {
            var opciones = new DbContextOptionsBuilder<MaryCarmenDBContext>()
                .UseSqlServer("Data Source=DESKTOP-05HME1I;Initial Catalog=MaryCarmenBD;Integrated Security=True;Encrypt=True;TrustServerCertificate=True")
                .Options;
            _MaryCarmenDBContext = new MaryCarmenDBContext(opciones);
            _usuarioServicio = new UsuarioServicioImpl(_MaryCarmenDBContext);
        }

        [Test]
        public async Task Test1()
        {
            var result = await _usuarioServicio.ListaPorRol(); 
            foreach (var item in result)
            {
                Console.WriteLine(item.idTipo + "-" + item.UsuRolSuc);
                foreach (var item2 in item.NombreSucRol)
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