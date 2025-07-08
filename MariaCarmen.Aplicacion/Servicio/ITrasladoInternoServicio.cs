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
    public interface ITrasladoInternoServicio
    {
        [OperationContract]
        Task TrasladoInternoAddAsync(traslados_internos TEntity); // Insertar
        [OperationContract]
        Task TrasladoInternoUpdateAsync(traslados_internos Entity); //Actualizar
        [OperationContract]
        Task TrasladoInternoDeleteAsync(int id); //Eliminar
        [OperationContract]
        Task<IEnumerable<traslados_internos>> TrasladoInternoGetAllAsync(); //listar todo
        [OperationContract]
        Task<traslados_internos> TrasladoInternoGetByIdAseync(int id); //buscar por id
        Task<List<TrasUsuRolDTO>> listadetallefecha();// listar por rol
    }
}
