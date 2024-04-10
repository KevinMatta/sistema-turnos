using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_Turnos.Common.Models
{
    public class EstadoCivilViewModel
    {
        public int EsCi_Id { get; set; }
        public string EsCi_Descripcion { get; set; }
        public bool? EsCi_Estado { get; set; }
        public int EsCi_Creacion { get; set; }
        public DateTime EsCi_FechaCreacion { get; set; }
        public int? EsCi_Modificacion { get; set; }
        public DateTime? EsCi_FechaModificacion { get; set; }

        [NotMapped]
        public string usua_creac { get; set; }

        [NotMapped]
        public string usua_modi { get; set; }
    }
}
