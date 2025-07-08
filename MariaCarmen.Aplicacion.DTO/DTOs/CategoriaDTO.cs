using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MariaCarmen.Aplicacion.DTO.DTOs
{
    public class CategoriaDTO
    {
        public int Recuperar { get; set; }

        public string idTipo { get; set; }

        public List<string> Datos { get; set; }
    }
}
