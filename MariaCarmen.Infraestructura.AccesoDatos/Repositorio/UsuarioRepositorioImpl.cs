using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MariaCarmen.Aplicacion.DTO.DTOs;
using MariaCarmen.Dominio.Modelos.Abstracciones;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.Internal;

namespace MariaCarmen.Infraestructura.AccesoDatos.Repositorio
{
    public class UsuarioRepositorioImpl : RepositorioImpl<usuarios>, IUsuariosRepositorio
    {
        private readonly MaryCarmenDBContext _MaryCarmenDBContext;
        public UsuarioRepositorioImpl(MaryCarmenDBContext dBContext) : base(dBContext)
        {
            this._MaryCarmenDBContext = dBContext;
        }

        public IEnumerable<usuarios> buscarPorNombreUsuario(string nombre_usuario)
        {
            throw new NotImplementedException();
        }

        public async Task<List<UsuarioRolSucDTO>> ListaPorRol()
        {
            try
            {
                var result = await(from usu in _MaryCarmenDBContext.usuarios
                                   join rl in _MaryCarmenDBContext.roles
                                   on usu.id_rol equals rl.id_rol
                                   join suc in _MaryCarmenDBContext.sucursales
                                   on usu.id_sucursal equals suc.id_sucursal
                                   group usu by new { usu.nombre_usuario,rl.nombre_rol, suc.nombre_sucursal, usu.id_usuario } into grupo
                                   select new UsuarioRolSucDTO
                                   {
                                       idTipo = grupo.Key.id_usuario,
                                       Recuperar = grupo.Key.nombre_usuario,
                                       Datos = grupo.Select(tmp => tmp.nombre_completo).ToList(),

                                   }).ToListAsync();
                return result;

            }
            catch (Exception ex)
            {

                throw new Exception("Error al listar producto por tipo" + ex.Message);

            }
        }
    }
}
