using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MariaCarmen.Aplicacion.DTO.DTOs;
using MariaCarmen.Infraestructura.AccesoDatos;

namespace MariaCarmen.Dominio.Modelos.Abstracciones
{
    public interface IProductosRepositorio : IRepositorio<productos>
    {
        IEnumerable<productos> buscarProductoPorNombre(String nombre_prodcuto);

        Task<List<ProductosDTO>> ListarProductosPorTipo();
    }
}
