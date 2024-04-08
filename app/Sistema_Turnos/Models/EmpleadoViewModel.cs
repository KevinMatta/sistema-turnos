using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Sistema_Turnos.Models
{
    public class EmpleadoViewModel
    {
        public int Empl_Id { get; set; }
        public string Pers_Identidad { get; set; }
        public int? Usua_Id { get; set; }
        public int? Carg_Id { get; set; }
        public int? Hosp_Id { get; set; }
        public bool? Empl_Estado { get; set; }
        public int Empl_Creacion { get; set; }
        public DateTime Empl_FechaCreacion { get; set; }
        public int? Empl_Modificacion { get; set; }
        public DateTime? Empl_FechaModificacion { get; set; }

        //extra
        [NotMapped]
        public string Nombre { get; set; }
    }
}
