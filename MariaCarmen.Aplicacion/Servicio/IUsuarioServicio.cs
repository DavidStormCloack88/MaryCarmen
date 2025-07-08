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
    public interface IUsuarioServicio
    {
        [OperationContract]
        Task UsuarioAddAsync(usuarios TEntity); // Insertar
        [OperationContract]
        Task UsuarioUpdateAsync(usuarios Entity); //Actualizar
        [OperationContract]
        Task UsuarioDeleteAsync(int id); //Eliminar
        [OperationContract]
        Task<IEnumerable<usuarios>> UsuarioGetAllAsync(); //listar todo
        [OperationContract]
        Task<usuarios> UsuarioGetByIdAseync(int id); //buscar por id
        Task<List<UsuarioRolSucDTO>> ListaPorRol();// listar por rol
    }
}
