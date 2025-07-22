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
    public class TrasladoInternoServicioImpl : ITrasladoInternoServicio
    {
        private readonly ITrasladoInternoRepositorio _trasladointernoRepositorio;


        public TrasladoInternoServicioImpl(MaryCarmenDBContext MaryCarmenDBContext)
        {
            this._trasladointernoRepositorio = new TrasladoInternoRepositorioImpl(MaryCarmenDBContext);
        }

        public Task<List<TrasUsuRolDTO>> listadetallefecha()
        {
            return _trasladointernoRepositorio.listadetallefecha();
        }

        public async Task TrasladoInternoAddAsync(traslados_internos TEntity)
        {
            await _trasladointernoRepositorio.AddAsync(TEntity);
        }

        public Task TrasladoInternoDeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<traslados_internos>> TrasladoInternoGetAllAsync()
        {
            return _trasladointernoRepositorio.GetAllAsync();
        }

        public Task<traslados_internos> TrasladoInternoGetByIdAseync(int id)
        {
            return _trasladointernoRepositorio.GetByIdAsync(id);
        }

        public async Task TrasladoInternoUpdateAsync(traslados_internos Entity)
        {
            await _trasladointernoRepositorio.UpdateAsync(Entity);
        }
    }
}

        