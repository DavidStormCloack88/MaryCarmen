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

        public Task TrasladoInternoAddAsync(traslados_internos TEntity)
        {
            throw new NotImplementedException();
        }

        public Task TrasladoInternoDeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<traslados_internos>> TrasladoInternoGetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<traslados_internos> TrasladoInternoGetByIdAseync(int id)
        {
            throw new NotImplementedException();
        }

        public Task TrasladoInternoUpdateAsync(traslados_internos Entity)
        {
            throw new NotImplementedException();
        }
    }
}

        