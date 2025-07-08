using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MariaCarmen.Dominio.Modelos.Abstracciones;
using Microsoft.EntityFrameworkCore;

namespace MariaCarmen.Infraestructura.AccesoDatos.Repositorio
{
    public class RepositorioImpl<T> : IRepositorio<T> where T : class
    {
        //VARIABLES PARA UTILIZAR EL DBCONTEXT
        private readonly MaryCarmenDBContext _dbContext;
        private readonly DbSet<T> _dbSet;

        //CONSTRUCTOR DE LA CLASE PARA UTILIZAR ELL DBCONTEXT
        public RepositorioImpl(MaryCarmenDBContext dBContext)
        {
            _dbContext = dBContext;
            _dbSet = dBContext.Set<T>();
        }

        public async Task AddAsync(T TEntity)
        {

            try
            {
                await _dbSet.AddAsync(TEntity);
                await _dbContext.SaveChangesAsync();
            }
            catch (Exception e)
            {
                throw new Exception("Error: No se pudo insertar Datos " + e.Message);
            }
        }

        public async Task DeleteAsync(int id)
        {
            try
            {
                var entity = await GetByIdAsync(id);
                _dbSet.Remove(entity);
                await _dbContext.SaveChangesAsync();
            }
            catch (Exception e)
            {
                throw new Exception("Error: No se pudo eliminar Datos " + e.Message);
            }
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            try
            {

                return await _dbSet.ToListAsync();

            }
            catch (Exception e)
            {
                throw new Exception("Error: No se pudo listar Datos " + e.Message);
            }
        }

        public async Task<T> GetByIdAsync(int id)
        {
            try
            {
                return await _dbSet.FindAsync();
            }
            catch (Exception e)
            {
                throw new Exception("Error: No se pudo buscar por id los Datos " + e.Message);
            }
        }

        public async Task UpdateAsync(T Entity)
        {
            try
            {
                _dbSet.Update(Entity);
                await _dbContext.SaveChangesAsync();
            }
            catch (Exception e)
            {
                throw new Exception("Error: No se pudo actualizar Datos " + e.Message);
            }
        }
    }
}
