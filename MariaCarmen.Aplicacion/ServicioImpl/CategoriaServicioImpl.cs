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
    public class CategoriaServicioImpl : ICategoriaServicio
    {
        private ICategoriaRepositorio categoriaRepositorio;

        public CategoriaServicioImpl(MaryCarmenDBContext MaryCarmenDBContext)
        {
            this.categoriaRepositorio = new CategoriaRepositorioImpl(MaryCarmenDBContext);
        }
        public async Task CategoriaAddAsync(categoria TEntity)
        {
            await categoriaRepositorio.AddAsync(TEntity);
        }

        public async Task CategoriaDeleteAsync(int id)
        {
            await categoriaRepositorio.DeleteAsync(id);
        }

        public  Task<IEnumerable<categoria>> CategoriaGetAllAsync()
        {
           return categoriaRepositorio.GetAllAsync();
        }

        public Task<categoria> CategoriaGetByIdAseync(int id)
        {
            return categoriaRepositorio.GetByIdAsync(id);
        }

        public async Task CategoriaUpdateAsync(categoria Entity)
        {
            await categoriaRepositorio.UpdateAsync(Entity);
        }

        public Task<List<CategoriaDTO>> ListaPorNombre()
        {
            return categoriaRepositorio.ListaPorNombre();
        }
    }
}
