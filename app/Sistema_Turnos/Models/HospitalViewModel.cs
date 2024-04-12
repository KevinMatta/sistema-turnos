using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Sistema_Turnos.Models
{
    public class HospitalViewModel
    {
        [Display(Name = "ID")]
        public int Hosp_Id { get; set; }
        [Display(Name = "Descripcion")]
        public string Hosp_Descripcion { get; set; }
        [Display(Name = "Direccion")]
        public string Hosp_Direccion { get; set; }
        [Display(Name = "Municipio")]
        public string Ciud_Id { get; set; }
        public bool? Hosp_Estado { get; set; }
        public int Hosp_Creacion { get; set; }
        public DateTime Hosp_FechaCreacion { get; set; }
        public int? Hosp_Modificacion { get; set; }
        public DateTime? Hosp_FechaModificacion { get; set; }
        [Display(Name = "Departamento")]

        public string Esta_Id { get; set; }

        [Display(Name = "Municipio")]
        [NotMapped]
        public string Ciud_Descripcion { get; set; }

        [Display(Name = "Departamento")]
        [NotMapped]
        public string Esta_Descripcion { get; set; }

        [NotMapped]
        public string usua_creac { get; set; }

        [NotMapped]
        public string usua_modi { get; set; }

    }
}
