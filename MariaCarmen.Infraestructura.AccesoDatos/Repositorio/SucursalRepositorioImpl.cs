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
    public class SucursalRepositorioImpl : RepositorioImpl<sucursales>, ISucursalesRepositorio
    {
        private readonly MaryCarmenDBContext _MaryCarmenDBContext;

        public SucursalRepositorioImpl(MaryCarmenDBContext dBContext) : base(dBContext)
        {
            this._MaryCarmenDBContext = dBContext;
        }

        public async Task<List<UsuVentSucuDTO>> ListarporSucursal()
        {
            try
            {
                var result = await(from vent in _MaryCarmenDBContext.ventas
                                   join suc in _MaryCarmenDBContext.sucursales
                                   on vent.id_sucursal equals suc.id_sucursal
                                   join usu in _MaryCarmenDBContext.usuarios
                                   on suc.id_sucursal equals usu.id_sucursal
                                   group usu by new { usu.nombre_completo,usu.id_usuario, suc.nombre_sucursal, vent.metodo_pago } into grupo
                                   select new UsuVentSucuDTO
                                   {
                                       idTipo = grupo.Key.id_usuario,
                                       Recuperar = grupo.Key.nombre_sucursal,
                                       Datos = grupo.Select(tmp => tmp.nombre_completo).ToList(),

                                   }).ToListAsync();
                return result;

            }
            catch (Exception ex)
            {

                throw new Exception("Error al listar producto por tipo" + ex.Message);

            }
        }

        public IEnumerable<sucursales> nombreSucursal(string nombre_sucursal)
        {
            throw new NotImplementedException();
        }
    }
}
