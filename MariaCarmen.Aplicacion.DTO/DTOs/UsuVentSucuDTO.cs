using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MariaCarmen.Aplicacion.DTO.DTOs
{
    public class UsuVentSucuDTO
    {
        public string Recuperar { get; set; } //recuperar nombre del tipo producto

        public int idTipo { get; set; }
        public List<string> Datos { get; set; }//listar todo los productos de acuerdo al tipo
    }
}
