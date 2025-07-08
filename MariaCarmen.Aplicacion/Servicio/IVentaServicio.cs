using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using MariaCarmen.Aplicacion.DTO.DTOs;
using MariaCarmen.Infraestructura.AccesoDatos;

namespace MariaCarmen.Aplicacion.Servicio
{
    public interface IVentaServicio
    {
        [OperationContract]
        Task VentaAddAsync(ventas TEntity); // Insertar
        [OperationContract]
        Task VentaUpdateAsync(ventas Entity); //Actualizar
        [OperationContract]
        Task VentaDeleteAsync(int id); //Eliminar
        [OperationContract]
        Task<IEnumerable<ventas>> VentaGetAllAsync(); //listar todo
        [OperationContract]
        Task<ventas> VentaGetByIdAseync(int id); //buscar por id
        [OperationContract]
        Task<List<VentaProductoFechaDTO>> ListaPorFecha();// listar por fecha de venta
        [OperationContract]
        Task<List<ventas>> OrdenFecha();
    }
}
