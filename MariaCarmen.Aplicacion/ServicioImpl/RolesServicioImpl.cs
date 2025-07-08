using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MariaCarmen.Aplicacion.Servicio;
using MariaCarmen.Dominio.Modelos.Abstracciones;
using MariaCarmen.Infraestructura.AccesoDatos;
using MariaCarmen.Infraestructura.AccesoDatos.Repositorio;

namespace MariaCarmen.Aplicacion.ServicioImpl
{
    public class RolesServicioImpl : IRolesServicio
    {
        private IRolesRepositorio rolesRepositorio;

        public RolesServicioImpl(MaryCarmenDBContext maryCarmenDBContext)
        {
            this.rolesRepositorio = new RolesRepositorioImpl(maryCarmenDBContext);  
        }

        public Task<List<roles>> ListarolEmpleado()
        {
            return rolesRepositorio.ListarolEmpleado();
        }

        public async Task RolesAddAsync(roles TEntity)
        {
            await rolesRepositorio.AddAsync(TEntity);
        }

        public async Task RolesDeleteAsync(int id)
        {
            await rolesRepositorio.DeleteAsync(id);
        }

        public Task<IEnumerable<roles>> RolesGetAllAsync()
        {
            return rolesRepositorio.GetAllAsync();
        }

        public Task<roles> RolesGetByIdAseync(int id)
        {
            return rolesRepositorio.GetByIdAsync(id);
        }

        public async Task RolesUpdateAsync(roles Entity)
        {
            await rolesRepositorio.UpdateAsync(Entity);
        }
    }
}
