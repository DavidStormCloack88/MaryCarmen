using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MariaCarmen.Aplicacion.DTO.DTOs
{
    public class TrasUsuRolDTO
    {
        public string Recuperar { get; set; } //recuperar la fecha de traslado

        public DateOnly idTipo { get; set; }
        public List<string> Datos { get; set; }//listar todo los usuarios de acuerdo al rol
    }
}
