using MariaCarmen.Aplicacion.Servicio;
using MariaCarmen.Aplicacion.ServicioImpl;
using MariaCarmen.Infraestructura.AccesoDatos;
using MariaCarmen.Infraestructura.AccesoDatos.Repositorio;
using Microsoft.EntityFrameworkCore;

namespace Consulta1Simple
{
    public class Tests
    {
        
        private IProductoServicio _productoServicio;
        private MaryCarmenDBContext _MaryCarmenDBContext;
        [SetUp]
        public void Setup()
        {
            {
                var opciones = new DbContextOptionsBuilder<MaryCarmenDBContext>()
                .UseSqlServer("Data Source=PROGRAMADOR;Initial Catalog=MaryCarmenBD;Integrated Security=True;TrustServerCertificate=True")
                .Options;
                _MaryCarmenDBContext = new MaryCarmenDBContext(opciones);
                _productoServicio = new CProductosServicioImpl(_MaryCarmenDBContext);
                
            }
        }

        [Test]
        public async Task Test1()
        {
            var result = await _productoServicio.ListarProductoPorTipo();
            foreach (var item in result) { 
                Console.WriteLine(item.idTipo+"-"+item.NombreTipoProducto);
                foreach (var item2 in item.NombresProductos) {
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