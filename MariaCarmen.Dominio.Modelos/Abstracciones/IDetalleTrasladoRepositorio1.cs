using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MariaCarmen.Infraestructura.AccesoDatos;

namespace MariaCarmen.Dominio.Modelos.Abstracciones
{
    public interface IDetalleTrasladoRepositorio1 : IRepositorio<detalle_traslado>
    {
        IEnumerable<detalle_traslado> buscarPorID(int id);
    }
}
