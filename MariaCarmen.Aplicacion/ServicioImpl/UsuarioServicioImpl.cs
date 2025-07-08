using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MariaCarmen.Aplicacion.DTO.DTOs;
using MariaCarmen.Aplicacion.Servicio;
using MariaCarmen.Dominio.Modelos.Abstracciones;
using MariaCarmen.Infraestructura.AccesoDatos;
using MariaCarmen.Infraestructura.AccesoDatos.Repositorio;

namespace MariaCarmen.Aplicacion.ServicioImpl
{
    public class UsuarioServicioImpl : IUsuarioServicio
    {
        private readonly IUsuariosRepositorio _usuariosRepositorio;

        public UsuarioServicioImpl(MaryCarmenDBContext MaryCarmenDBContext) 
        {
            this._usuariosRepositorio = new UsuarioRepositorioImpl(MaryCarmenDBContext);
        }

        public Task<List<UsuarioRolSucDTO>> ListaPorRol()
        {
            return _usuariosRepositorio.ListaPorRol();
        }

        public Task UsuarioAddAsync(usuarios TEntity)
        {
            throw new NotImplementedException();
        }

        public Task UsuarioDeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<usuarios>> UsuarioGetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<usuarios> UsuarioGetByIdAseync(int id)
        {
            throw new NotImplementedException();
        }

        public Task UsuarioUpdateAsync(usuarios Entity)
        {
            throw new NotImplementedException();
        }
    }
}
