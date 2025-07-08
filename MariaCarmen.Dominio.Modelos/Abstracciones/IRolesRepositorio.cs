using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MariaCarmen.Infraestructura.AccesoDatos;

namespace MariaCarmen.Dominio.Modelos.Abstracciones
{
    public interface IRolesRepositorio : IRepositorio<roles>
    {
        IEnumerable<roles> rolEmpleado(String empleado);
        Task<List<roles>> ListarolEmpleado();
    }
}
