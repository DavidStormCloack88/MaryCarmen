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
    public interface ICategoriaServicio
    {
        [OperationContract]
        Task CategoriaAddAsync(categoria TEntity); // Insertar
        [OperationContract]
        Task CategoriaUpdateAsync(categoria Entity); //Actualizar
        [OperationContract]
        Task CategoriaDeleteAsync(int id); //Eliminar
        [OperationContract]
        Task<IEnumerable<categoria>> CategoriaGetAllAsync(); //listar todo
        [OperationContract]
        Task <categoria> CategoriaGetByIdAseync(int id); //buscar por id
        Task<List<CategoriaDTO>> ListaPorNombre();// listar por nombre la categoria
    }
}
