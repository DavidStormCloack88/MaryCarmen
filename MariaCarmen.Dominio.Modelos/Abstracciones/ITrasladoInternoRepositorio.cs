using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MariaCarmen.Aplicacion.DTO.DTOs;
using MariaCarmen.Infraestructura.AccesoDatos;

namespace MariaCarmen.Dominio.Modelos.Abstracciones
{
    public interface ITrasladoInternoRepositorio : IRepositorio<traslados_internos>
    {
        IEnumerable<traslados_internos> buscarPorFechaEnvio(DateOnly fecha_envio);
        Task<List<TrasUsuRolDTO>> listadetallefecha();
    }
}
