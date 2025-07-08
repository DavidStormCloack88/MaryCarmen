using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using MariaCarmen.Infraestructura.AccesoDatos;

namespace MariaCarmen.Aplicacion.Servicio
{
    public interface IRolesServicio
    {
        [OperationContract]
        Task RolesAddAsync(roles TEntity); //insertar
        [OperationContract]
        Task RolesUpdateAsync(roles Entity); //Actualizar
        [OperationContract]
        Task RolesDeleteAsync(int id); //Eliminar
        [OperationContract]
        Task<IEnumerable<roles>> RolesGetAllAsync(); //listar todo
        [OperationContract]
        Task<roles> RolesGetByIdAseync(int id); //buscar por id

        [OperationContract]
        Task<List<roles>> ListarolEmpleado(); 


    }
}
