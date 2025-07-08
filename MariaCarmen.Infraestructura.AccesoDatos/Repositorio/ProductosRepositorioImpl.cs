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
    public class ProductosRepositorioImpl : RepositorioImpl<productos>, IProductosRepositorio
    {
        private readonly MaryCarmenDBContext _MaryCarmenDBContext;
        public ProductosRepositorioImpl(MaryCarmenDBContext dBContext) : base(dBContext)
        {
            this._MaryCarmenDBContext = dBContext;
        }

        public IEnumerable<productos> buscarProductoPorNombre(string nombre_prodcuto)
        {
            throw new NotImplementedException();
        }

        public async Task<List<ProductosDTO>> ListarProductosPorTipo()
        {
            try
            {
                var resultado = await(from prod in _MaryCarmenDBContext.productos
                                      join cat in _MaryCarmenDBContext.categoria
                                      on prod.id_categoria equals cat.id_categoria
                                      group prod by new { prod.nombre_producto, cat.id_categoria} into grupo
                                      select new ProductosDTO
                                      {
                                          idTipo = grupo.Key.id_categoria,
                                          NombreTipoProducto = grupo.Key.nombre_producto,
                                          NombresProductos = grupo.Select(tmp => tmp.nombre_producto).ToList()
                                      }).ToListAsync();
                return resultado;

            }
            catch (Exception ex)
            {

                throw new Exception("Error al listar producto por tipo" + ex.Message);

            }
        }
    }
}
