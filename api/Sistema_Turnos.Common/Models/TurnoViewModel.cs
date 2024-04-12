using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_Turnos.Common.Models
{
    public class TurnoViewModel
    {
        public int Turn_Id { get; set; }
        public string Turn_Descripcion { get; set; }
        public string Turn_HoraEntrada { get; set; }
        public bool? Turn_Estado { get; set; }
        public int Turn_Creacion { get; set; }
        public DateTime Turn_FechaCreacion { get; set; }
        public int? Turn_Modificacion { get; set; }
        public DateTime? Turn_FechaModificacion { get; set; }
        public string Turn_HoraSalida { get; set; }

        [NotMapped]
        public string usua_creac { get; set; }

        [NotMapped]
        public string usua_modi { get; set; }
    }
}
