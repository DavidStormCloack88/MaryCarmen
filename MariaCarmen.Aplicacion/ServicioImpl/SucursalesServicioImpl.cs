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
    public class SucursalesServicioImpl : ISucursalesServicio
    {
        private readonly ISucursalesRepositorio _sucursalesRepositorio;

        public SucursalesServicioImpl(MaryCarmenDBContext MaryCarmenDBContext)
        {
            this._sucursalesRepositorio = new SucursalRepositorioImpl(MaryCarmenDBContext);
        }

        public Task<List<UsuVentSucuDTO>> ListarporSucursal()
        {
            return _sucursalesRepositorio.ListarporSucursal();
        }

        public Task SucursalesAddAsync(sucursales TEntity)
        {
            throw new NotImplementedException();
        }

        public Task SucursalesDeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<sucursales>> SucursalesGetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<sucursales> SucursalesGetByIdAseync(int id)
        {
            throw new NotImplementedException();
        }

        public Task SucursalesUpdateAsync(sucursales Entity)
        {
            throw new NotImplementedException();
        }
    }
}
