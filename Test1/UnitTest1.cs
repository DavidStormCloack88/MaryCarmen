using System.Threading.Tasks;
using MariaCarmen.Aplicacion.Servicio;
using MariaCarmen.Aplicacion.ServicioImpl;
using MariaCarmen.Infraestructura.AccesoDatos;
using MariaCarmen.Infraestructura.AccesoDatos.Repositorio;
using Microsoft.EntityFrameworkCore;

namespace TestCategoria
{
    public class Tests
    {
        //VARIABLES PARA CONSUMIR LA ARQUITECTURA DESDE LA APLICACION
        private ICategoriaServicio _categoriaServicio;
        private MaryCarmenDBContext _MaryCarmenDBContext;
        [SetUp]
        public void Setup()
        {
            { var opciones = new DbContextOptionsBuilder<MaryCarmenDBContext>()
                .UseSqlServer("Data Source=PROGRAMADOR;Initial Catalog=MaryCarmenBD;Integrated Security=True;TrustServerCertificate=True")
                .Options;
            _MaryCarmenDBContext = new MaryCarmenDBContext(opciones);
            _categoriaServicio = new CategoriaServicioImpl(_MaryCarmenDBContext);
            }
        }

        [Test]
        public async Task Test1()
        {
            var cat = new categoria
            {
                nombre_categoria = "Casual",
                tipo_categoria = "Adulto"
            };

            await _categoriaServicio.CategoriaAddAsync(cat);
          
            //Assert.Pass();
        }

        [TearDown]
        public void DespuesTest()
        {
            _MaryCarmenDBContext.Dispose();
        }
    }
}