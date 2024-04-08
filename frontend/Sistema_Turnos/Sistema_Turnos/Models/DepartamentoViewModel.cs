using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Sistema_Turnos.Models
{
    public class DepartamentoViewModel
    {
        [Display(Name = "Codigo")]
        public string Esta_Id { get; set; }
        [Display(Name = "Departamento")]
        public string Esta_Descripcion { get; set; }
        [Display(Name = "Usuario Creacion")]
        public int Esta_Creacion { get; set; }
        [Display(Name = "Fecha Creacion")]
        public DateTime Esta_FechaCreacion { get; set; }
        [Display(Name = "Usuario Modificacion")]
        public int? Esta_Modificacion { get; set; }
        [Display(Name = "Usuario Modificacion")]
        public DateTime? Esta_FechaModificacion { get; set; }
    }
}
