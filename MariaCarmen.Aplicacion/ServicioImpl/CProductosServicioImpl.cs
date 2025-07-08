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
        private readonly IProductosRepositorio productosRepositorio;

        public CProductosServicioImpl(MaryCarmenDBContext MaryCarmenDBContext)
        {
            this.productosRepositorio = new ProductosRepositorioImpl(MaryCarmenDBContext);
        }

        public Task<List<ProductosDTO>> ListarProductoPorTipo()
        {
            return productosRepositorio.ListarProductosPorTipo();
        }

        public Task ProductoAddAsync(productos TEntity)
        {
            throw new NotImplementedException();
        }

        public Task ProductoDeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<productos>> ProductoGetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<productos> ProductoGetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task ProductoUpdateAsync(productos Entity)
        {
            throw new NotImplementedException();
        }
    }
}
