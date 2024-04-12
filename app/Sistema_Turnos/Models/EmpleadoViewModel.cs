using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Sistema_Turnos.Models
{
    public class EmpleadoViewModel
    {
        [Display(Name = "ID")]
        public int Empl_Id { get; set; }
        [Display(Name = "Persona")]
        public string Pers_Identidad { get; set; }
        [Display(Name = "Usario")]
        public int? Usua_Id { get; set; }
        [Display(Name = "Cargo")]
        public int? Carg_Id { get; set; }
        [Display(Name = "Sucursal")]
        public int? Hosp_Id { get; set; }
        public bool? Empl_Estado { get; set; }
        public int Empl_Creacion { get; set; }
        public DateTime Empl_FechaCreacion { get; set; }
        public int? Empl_Modificacion { get; set; }
        public DateTime? Empl_FechaModificacion { get; set; }

        //extra
        [Display(Name = "Nombre")]
        [NotMapped]
        public string Nombre { get; set; }

        [NotMapped]
        public string usua_creac { get; set; }

        [NotMapped]
        public string usua_modi { get; set; }

        [Display(Name = "Cargo")]
        [NotMapped]
        public string Carg_Descripcion { get; set; }

        [Display(Name = "Sucursal")]
        [NotMapped]
        public string Hosp_Descripcion { get; set; }

        [Display(Name = "Sucursal")]
        [NotMapped]
        public string usuario { get; set; }
    }
}
