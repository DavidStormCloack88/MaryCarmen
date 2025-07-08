using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MariaCarmen.Aplicacion.DTO.DTOs
{
    public class UsuarioRolSucDTO 
    {
        public string Recuperar { get; set; } //recuperar nombre del usuario

        public int idTipo { get; set; }
        public List<string> Datos { get; set; }//listar todas las ventas de las sucursales por el usuario
    }
}
