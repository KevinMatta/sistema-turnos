using Sistema_Turnos.Entities.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_Turnos.Common.Models
{
    public class RolViewModel
    {
        public int Rol_Id { get; set; }
        public string Rol_Descripcion { get; set; }
        public int Rol_Creacion { get; set; }
        public DateTime Rol_FechaCreacion { get; set; }
        public int? Rol_Modificacion { get; set; }
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
