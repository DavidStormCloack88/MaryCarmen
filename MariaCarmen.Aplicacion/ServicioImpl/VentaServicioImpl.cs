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
    public class VentaServicioImpl : IVentaServicio
    {
        private readonly IVentaRepositorio _ventaRepositorio;

        public VentaServicioImpl(MaryCarmenDBContext MaryCarmenDBContext)
        {
            this._ventaRepositorio = new VentaRepositorioImpl(MaryCarmenDBContext);
        }

        public Task<List<VentaProductoFechaDTO>> ListaPorFecha()
        {
            return _ventaRepositorio.ListaPorFecha();
        }

        public Task<List<ventas>> OrdenFecha()
        {
            return _ventaRepositorio.OrdenFecha();
        }

        public async Task VentaAddAsync(ventas TEntity)
        {
            await _ventaRepositorio.AddAsync(TEntity);
        }

        public Task VentaDeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ventas>> VentaGetAllAsync()
        {
            return _ventaRepositorio.GetAllAsync();
        }

        public Task<ventas> VentaGetByIdAseync(int id)
        {
            return _ventaRepositorio.GetByIdAsync(id);
        }

        public async Task VentaUpdateAsync(ventas Entity)
        {
            await _ventaRepositorio.UpdateAsync(Entity);
        }
    }
}
