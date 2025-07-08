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
    public class VentaRepositorioImpl : RepositorioImpl<ventas>, IVentaRepositorio
    {
        private readonly MaryCarmenDBContext _MaryCarmenDBContext;
        public VentaRepositorioImpl(MaryCarmenDBContext dBContext) : base(dBContext)
        {
            this._MaryCarmenDBContext = dBContext;
        }

        public IEnumerable<ventas> buscarPorFecha(string fecha_venta)
        {
            throw new NotImplementedException();
        }

        public async Task<List<VentaProductoFechaDTO>> ListaPorFecha()
        {
            try
            {
                var result = await (from prod in _MaryCarmenDBContext.productos
                                       join dv in _MaryCarmenDBContext.detalle_venta
                                       on prod.id_producto equals dv.id_producto
                                       join ven in _MaryCarmenDBContext.ventas
                                       on dv.id_venta equals ven.id_venta
                                       group prod by new {prod.nombre_producto, dv.id_detalle_venta, ven.fecha_hora_venta } into grupo
                                       select new VentaProductoFechaDTO
                                       {
                                           idTipo = grupo.Key.id_detalle_venta,
                                           ProductoVentaFec = grupo.Key.nombre_producto,
                                           NombresProductosFec = grupo.Select(tmp => tmp.nombre_producto).ToList()
                                       }).ToListAsync();
                return result;

            }
            catch (Exception ex)
            {

                throw new Exception("Error al listar producto por tipo" + ex.Message);

            }
        }

        public Task<List<ventas>> OrdenFecha()
        {

            try
            { //select * from tipo_producto where estado_registro=1
                var resultado = from vent in _MaryCarmenDBContext.ventas
                                orderby vent ascending
                                select vent;
                return resultado.ToListAsync();

            }
            catch (Exception e)
            {

                throw new Exception("Error al listar consulta," + e.Message);
            }
        }
    }
}
