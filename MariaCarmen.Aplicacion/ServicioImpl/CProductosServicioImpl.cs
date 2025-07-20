using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MariaCarmen.Aplicacion.DTO.DTOs;
using MariaCarmen.Aplicacion.Servicio;
using MariaCarmen.Dominio.Modelos.Abstracciones;
using MariaCarmen.Infraestructura.AccesoDatos;
using MariaCarmen.Infraestructura.AccesoDatos.Repositorio;

namespace MariaCarmen.Aplicacion.ServicioImpl
{
    public class CProductosServicioImpl : IProductoServicio
    {
        private  IProductosRepositorio productosRepositorio;
        private readonly MaryCarmenDBContext _MaryCarmenDBContext;

        public CProductosServicioImpl(MaryCarmenDBContext MaryCarmenDBContext)
        {
            _MaryCarmenDBContext = MaryCarmenDBContext;
            productosRepositorio = new ProductosRepositorioImpl(_MaryCarmenDBContext);
        }

        public Task<List<ProductosDTO>> ListarProductoPorTipo()
        {
            return productosRepositorio.ListarProductosPorTipo();
        }

        public async Task ProductoAddAsync(productos TEntity)
        {
            await productosRepositorio.AddAsync(TEntity);
        }

        public Task ProductoDeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<productos>> ProductoGetAllAsync()
        {
            return productosRepositorio.GetAllAsync();
        }

        public Task<productos> ProductoGetByIdAsync(int id)
        {
            return productosRepositorio.GetByIdAsync(id);
        }
        

        public async Task ProductoUpdateAsync(productos Entity)
        {
            await productosRepositorio.UpdateAsync(Entity);
        }
    }
}
