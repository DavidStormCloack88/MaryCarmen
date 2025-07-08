using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MariaCarmen.Aplicacion.DTO.DTOs;
using MariaCarmen.Dominio.Modelos.Abstracciones;
using Microsoft.EntityFrameworkCore;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace MariaCarmen.Infraestructura.AccesoDatos.Repositorio
{
    public class CategoriaRepositorioImpl : RepositorioImpl<categoria>, ICategoriaRepositorio
    {
        private readonly MaryCarmenDBContext _MaryCarmenDBContext;

        public CategoriaRepositorioImpl(MaryCarmenDBContext dBContext) : base(dBContext)
        {
            _MaryCarmenDBContext = dBContext;
        }

        public IEnumerable<categoria> buscarPorCtegoria(string categoria)
        {
            throw new NotImplementedException();
        }

        public async Task<List<CategoriaDTO>> ListaPorNombre()
        {
            try
            {
                var result = await(from cat in _MaryCarmenDBContext.categoria
                                   join prod in _MaryCarmenDBContext.productos
                                   on cat.id_categoria equals prod.id_categoria
                                   join dtras in _MaryCarmenDBContext.detalle_traslado
                                   on prod.id_producto equals dtras.id_producto
                                   group prod by new {prod.id_producto, prod.nombre_producto,cat.nombre_categoria,dtras.cantidad } into grupo
                                   select new CategoriaDTO
                                   {
                                       idTipo = grupo.Key.nombre_producto,
                                       Recuperar = grupo.Key.cantidad,
                                       Datos = grupo.Select(tmp => tmp.codigo_producto).ToList(),

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
