using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Sistema_Turnos.Models
{
    public class UsuarioViewModel
    {
        public int Usua_Id { get; set; }
        public string Usua_Usuario { get; set; }
        public string Usua_Clave { get; set; }
        public int? Rol_Id { get; set; }
        public bool? Usua_IsAdmin { get; set; }
        public bool? Usua_Estado { get; set; }
        public int Usua_Creacion { get; set; }
        public DateTime Usua_FechaCreacion { get; set; }
        public int? Usua_Modificacion { get; set; }
        public DateTime? Usua_FechaModificacion { get; set; }

        [NotMapped]
        public string Usua_Nombre { get; set; }

        [NotMapped]
        public byte[] Usua_Contrasenia { get; set; }

        [NotMapped]
        public string Usua_Administrador { get; set; }

        [NotMapped]
        public string Pant_Descripcion { get; set; }
    }
}
