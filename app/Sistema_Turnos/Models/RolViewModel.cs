using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Sistema_Turnos.Models
{
    public class RolViewModel
    {
        [Display(Name = "ID")]
        public int Rol_Id { get; set; }
        [Display(Name = "Rol")]
        public string Rol_Descripcion { get; set; }
        public int Rol_Creacion { get; set; }
        [Display(Name = "Fecha Creacion")]
        public DateTime Rol_FechaCreacion { get; set; }
        public int? Rol_Modificacion { get; set; }

        [Display(Name = "Fecha Modificacion")]
        public DateTime? Rol_FechaModificacion { get; set; }

        [NotMapped]
        public List<PantallaViewModel> pantallas { get; set; }

        [NotMapped]
        public List<int> PantallasID { get; set; }

        [NotMapped]
        public int Resultado { get; set; }

        [NotMapped]
        public string Nul { get; set; }
    }
}
