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
    public class DetalleVentaServicioImpl : IDetalleVentaServicio
    {
        private readonly IDetalleVentasRepositorio _detalleVentasRepositorio;

        public DetalleVentaServicioImpl(MaryCarmenDBContext MaryCarmenDBContext)
        {
            this._detalleVentasRepositorio = new DetalleVentaRepositorioImpl(MaryCarmenDBContext);  
        }

        public Task DetalleVentaAddAsync(detalle_venta TEntity)
        {
            throw new NotImplementedException();
        }

        public Task DetalleVentaDeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<detalle_venta>> DetalleVentaGetAllAsync()
        {
            return _detalleVentasRepositorio.GetAllAsync();
        }

        public Task<detalle_venta> DetalleVentaGetByIdAseync(int id)
        {
            throw new NotImplementedException();
        }

        public Task DetalleVentaUpdateAsync(detalle_venta Entity)
        {
            throw new NotImplementedException();
        }

        public Task<List<detalle_venta>> FiltrarCantidadVenta()
        {
            return _detalleVentasRepositorio.FiltrarCantidadVenta();
        }

        public Task<List<CatDetalleVentProdVentDTO>> ListaPorDetalleVenta()
        {
            return _detalleVentasRepositorio.ListaPorDetalleVenta();
        }
    }
}
