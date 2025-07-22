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

        public async Task UsuarioAddAsync(usuarios TEntity)
        {
            await _usuariosRepositorio.AddAsync(TEntity);
        }

        public Task UsuarioDeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<usuarios>> UsuarioGetAllAsync()
        {
            return _usuariosRepositorio.GetAllAsync();
        }

        public Task<usuarios> UsuarioGetByIdAseync(int id)
        {
            return _usuariosRepositorio.GetByIdAsync(id);
        }

        public async Task UsuarioUpdateAsync(usuarios Entity)
        {
            await _usuariosRepositorio.UpdateAsync(Entity);
        }
    }
}
