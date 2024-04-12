using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Sistema_Turnos.Models
{
    public class PersonaViewModel
    {
        [Display(Name = "Identidad")]
        public string Pers_Identidad { get; set; }
        [Display(Name = "Primer Nombre")]
        public string Pers_PrimerNombre { get; set; }
        [Display(Name = "Segundo Nombre")]
        public string Pers_SegundoNombre { get; set; }
        [Display(Name = "Primer Apellido")]
        public string Pers_PrimerApellido { get; set; }
        [Display(Name = "Segundo Apellido")]
        public string Pers_SegundoApellido { get; set; }
        [Display(Name = "Estado Civil")]
        public int EsCi_Id { get; set; }
        [Display(Name = "Sexo")]
        public string Pers_Sexo { get; set; }
        public bool? Pers_Estado { get; set; }
        public int Pers_Creacion { get; set; }
        public DateTime Pers_FechaCreacion { get; set; }
        public int? Pers_Modificacion { get; set; }
        public DateTime? Pers_FechaModificacion { get; set; }

        [NotMapped]
        public string usua_creac { get; set; }

        [NotMapped]
        public string usua_modi { get; set; }
    }
}
