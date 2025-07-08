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
    public interface ISucursalesServicio
    {
        [OperationContract]
        Task SucursalesAddAsync(sucursales TEntity); // Insertar
        [OperationContract]
        Task SucursalesUpdateAsync(sucursales Entity); //Actualizar
        [OperationContract]
        Task SucursalesDeleteAsync(int id); //Eliminar
        [OperationContract]
        Task<IEnumerable<sucursales>> SucursalesGetAllAsync(); //listar todo
        [OperationContract]
        Task<sucursales> SucursalesGetByIdAseync(int id); //buscar por id
        Task<List<UsuVentSucuDTO>> ListarporSucursal();// listar por nombre de detventa
    }
}
