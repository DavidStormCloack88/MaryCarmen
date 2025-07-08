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
    public class DetalleVentaRepositorioImpl : RepositorioImpl<detalle_venta>, IDetalleVentasRepositorio
    {
        private readonly MaryCarmenDBContext _MaryCarmenDBContext;

        public DetalleVentaRepositorioImpl(MaryCarmenDBContext dBContext) : base(dBContext)
        {
            this._MaryCarmenDBContext = dBContext;
        }

        public IEnumerable<detalle_venta> buscarPorNombreCliente(string nombre_cliente)
        {
            throw new NotImplementedException();
        }

        public Task<List<detalle_venta>> FiltrarCantidadVenta()
        {

            try
            { //select * from tipo_producto where estado_registro=1
                var resultado = from cant in _MaryCarmenDBContext.detalle_venta
                                where cant.cantidad < 5
                                select cant;
                return resultado.ToListAsync();

            }
            catch (Exception e)
            {

                throw new Exception("Error al listar consulta," + e.Message);
            }
        }

        public async Task<List<CatDetalleVentProdVentDTO>> ListaPorDetalleVenta()
        {
            try
            {
                var result = await(from cat in _MaryCarmenDBContext.categoria
                                   join prod in _MaryCarmenDBContext.productos
                                   on cat.id_categoria equals prod.id_categoria
                                   join detall in _MaryCarmenDBContext.detalle_venta
                                   on prod.id_producto equals detall.id_producto
                                   join vent in _MaryCarmenDBContext.ventas
                                   on detall.id_venta equals vent.id_venta
                                   group vent by new {cat.id_categoria, cat.nombre_categoria, prod.nombre_producto, detall.cantidad, vent.metodo_pago, vent.numero_factura_o_recibo } into grupo
                                   select new CatDetalleVentProdVentDTO
                                   {
                                       idTipo = grupo.Key.metodo_pago,
                                       Recuperar = grupo.Key.nombre_producto,
                                       Datos = grupo.Select(tmp => tmp.numero_factura_o_recibo).ToList(),

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
