using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MariaCarmen.Aplicacion.DTO.DTOs;
using MariaCarmen.Infraestructura.AccesoDatos;

namespace MariaCarmen.Dominio.Modelos.Abstracciones
{
    //Hereda de la clase Irepositorio
    public interface ICategoriaRepositorio : IRepositorio<categoria>
    {
        IEnumerable<categoria> buscarPorCtegoria(String categoria);

        Task<List<CategoriaDTO>> ListaPorNombre();
    }
}
