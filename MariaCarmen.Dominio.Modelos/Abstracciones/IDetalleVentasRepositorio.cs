using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MariaCarmen.Aplicacion.DTO.DTOs;
using MariaCarmen.Infraestructura.AccesoDatos;

namespace MariaCarmen.Dominio.Modelos.Abstracciones
{
    public interface IDetalleVentasRepositorio : IRepositorio<detalle_venta>
    {
        IEnumerable<detalle_venta> buscarPorNombreCliente(String nombre_cliente);

        Task<List<CatDetalleVentProdVentDTO>> ListaPorDetalleVenta();
        Task<List<detalle_venta>> FiltrarCantidadVenta();
    }
}
