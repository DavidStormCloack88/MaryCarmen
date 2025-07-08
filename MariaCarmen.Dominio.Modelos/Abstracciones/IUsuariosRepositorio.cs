using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MariaCarmen.Aplicacion.DTO.DTOs;
using MariaCarmen.Infraestructura.AccesoDatos;

namespace MariaCarmen.Dominio.Modelos.Abstracciones
{
    public interface IUsuariosRepositorio : IRepositorio<usuarios>
    {
        IEnumerable<usuarios> buscarPorNombreUsuario(String nombre_usuario);
        Task<List<UsuarioRolSucDTO>> ListaPorRol();
    }
}
