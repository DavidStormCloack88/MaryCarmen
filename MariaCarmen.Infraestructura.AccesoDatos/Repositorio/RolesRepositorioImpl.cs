using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MariaCarmen.Dominio.Modelos.Abstracciones;
using Microsoft.EntityFrameworkCore;

namespace MariaCarmen.Infraestructura.AccesoDatos.Repositorio
{
    public class RolesRepositorioImpl : RepositorioImpl<roles>, IRolesRepositorio
    {
        private readonly MaryCarmenDBContext _MaryCarmenDBContext;
        public RolesRepositorioImpl(MaryCarmenDBContext dBContext) : base(dBContext)
        {
            this._MaryCarmenDBContext = dBContext;
        }

        public IEnumerable<roles> rolEmpleado(string empleado)
        {
            var resultado = from role in _MaryCarmenDBContext.roles
                            where role.nombre_rol == empleado
                            select role;

            return resultado.ToList();
        }


        public Task<List<roles>> ListarolEmpleado()
        {
            try
            { //select * from tipo_producto where estado_registro=1
                var resultado = from role in _MaryCarmenDBContext.roles
                                where role.id_rol == 1
                                select role;
                return resultado.ToListAsync();

            }
            catch (Exception e)
            {

                throw new Exception("Error al listar consulta," + e.Message);
            }
        }
    }
}
