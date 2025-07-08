using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MariaCarmen.Aplicacion.DTO.DTOs;
using MariaCarmen.Infraestructura.AccesoDatos;

namespace MariaCarmen.Dominio.Modelos.Abstracciones
{
    public interface IVentaRepositorio : IRepositorio <ventas>
    {
        IEnumerable<ventas> buscarPorFecha(String fecha_venta);

        Task<List<VentaProductoFechaDTO>> ListaPorFecha();

        Task<List<ventas>>OrdenFecha();
    }
}
