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
    public interface IProductoServicio
    {
        [OperationContract]
        Task ProductoAddAsync(productos TEntity); //insertar
        [OperationContract]
        Task ProductoUpdateAsync(productos Entity);//actualizar
        [OperationContract]
        Task ProductoDeleteAsync(int id);//eliminar por ID
        
        [OperationContract]
        Task<IEnumerable<productos>> ProductoGetAllAsync();//listar todo
        [OperationContract]
        Task<productos> ProductoGetByIdAsync(int id);//buscar por ID

        [OperationContract]
        Task<List<ProductosDTO>> ListarProductoPorTipo();


    }
}

