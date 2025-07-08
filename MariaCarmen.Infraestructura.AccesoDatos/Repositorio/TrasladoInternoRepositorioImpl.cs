using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MariaCarmen.Aplicacion.DTO.DTOs;
using MariaCarmen.Dominio.Modelos.Abstracciones;
using Microsoft.EntityFrameworkCore;

namespace MariaCarmen.Infraestructura.AccesoDatos.Repositorio
{
    public class TrasladoInternoRepositorioImpl : RepositorioImpl<traslados_internos>, ITrasladoInternoRepositorio
    {
        private readonly MaryCarmenDBContext _MaryCarmenDBContext;

        public TrasladoInternoRepositorioImpl(MaryCarmenDBContext dBContext) : base(dBContext)
        {
            this._MaryCarmenDBContext = dBContext;
        }

        public IEnumerable<traslados_internos> buscarPorFechaEnvio(DateOnly fecha_envio)
        {
            throw new NotImplementedException();
        }

        public async Task<List<TrasUsuRolDTO>> listadetallefecha()
        {
            try
            {
                var result = await(from tras in _MaryCarmenDBContext.traslados_internos
                                   join usu in _MaryCarmenDBContext.usuarios
                                   on tras.id_usuario_recibe equals usu.id_usuario
                                   join rl in _MaryCarmenDBContext.roles
                                   on usu.id_rol equals rl.id_rol
                                   group usu by new { usu.nombre_completo, rl.nombre_rol, usu.id_usuario, tras.id_traslado, tras.fecha_hora_envio } into grupo
                                   select new TrasUsuRolDTO
                                   {
                                       idTipo = grupo.Key.fecha_hora_envio,
                                       Recuperar = grupo.Key.nombre_rol,
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
