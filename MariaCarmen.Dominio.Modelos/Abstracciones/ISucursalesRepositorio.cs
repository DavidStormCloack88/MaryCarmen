using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MariaCarmen.Aplicacion.DTO.DTOs;
using MariaCarmen.Infraestructura.AccesoDatos;

namespace MariaCarmen.Dominio.Modelos.Abstracciones
{
    public interface ISucursalesRepositorio : IRepositorio<sucursales>
    {
        IEnumerable<sucursales> nombreSucursal(string nombre_sucursal);
        Task<List<UsuVentSucuDTO>> ListarporSucursal();
    }
}
