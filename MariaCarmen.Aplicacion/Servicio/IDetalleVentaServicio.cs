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
    public interface IDetalleVentaServicio
    {
        [OperationContract]
        Task DetalleVentaAddAsync(detalle_venta TEntity); // Insertar
        [OperationContract]
        Task DetalleVentaUpdateAsync(detalle_venta Entity); //Actualizar
        [OperationContract]
        Task DetalleVentaDeleteAsync(int id); //Eliminar
        [OperationContract]
        Task<IEnumerable<detalle_venta>> DetalleVentaGetAllAsync(); //listar todo
        [OperationContract]
        Task<detalle_venta> DetalleVentaGetByIdAseync(int id); //buscar por id
        [OperationContract]
        Task<List<CatDetalleVentProdVentDTO>> ListaPorDetalleVenta();// listar por nombre de detventa
        [OperationContract]
        Task<List<detalle_venta>> FiltrarCantidadVenta();

    }
}
