using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_Turnos.Common.Models
{
    class TurnoViewModel
    {
        public int Turn_Id { get; set; }
        public string Turn_Descripcion { get; set; }
        public TimeSpan Turn_HoraEntrada { get; set; }
        public bool? Turn_Estado { get; set; }
        public int Turn_Creacion { get; set; }
        public DateTime Turn_FechaCreacion { get; set; }
        public int? Turn_Modificacion { get; set; }
        public DateTime? Turn_FechaModificacion { get; set; }
        public TimeSpan? Turn_HoraSalida { get; set; }
    }
}
