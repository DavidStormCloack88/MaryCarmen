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

        public async Task SucursalesAddAsync(sucursales TEntity)
        {
            await _sucursalesRepositorio.AddAsync(TEntity);
        }

        public Task SucursalesDeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<sucursales>> SucursalesGetAllAsync()
        {
            return _sucursalesRepositorio.GetAllAsync();
        }

        public Task<sucursales> SucursalesGetByIdAseync(int id)
        {
            return _sucursalesRepositorio.GetByIdAsync(id);
        }

        public async Task SucursalesUpdateAsync(sucursales Entity)
        {
            await _sucursalesRepositorio.UpdateAsync(Entity);
        }
    }
}
