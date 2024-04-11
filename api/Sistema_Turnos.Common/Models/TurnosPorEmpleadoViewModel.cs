using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_Turnos.Common.Models
{
    public class TurnosPorEmpleadoViewModel
    {
        public int TuEm_Id { get; set; }
        public DateTime TuEm_FechaInicio { get; set; }
        public int Turn_Id { get; set; }
        public int Empl_Id { get; set; }
        public string TuEm_HoraEntrada { get; set; }
        public string TuEm_HoraSalida { get; set; }
        public bool? TuEm_Estado { get; set; }
        public int TuEm_Creacion { get; set; }
        public DateTime TuEm_FechaCreacion { get; set; }
        public int? TuEm_Modificacion { get; set; }
        public DateTime? TuEm_FechaModificacion { get; set; }

        //campos extras
        [NotMapped]
        public int url { get; set; }
        [NotMapped]
        public int id { get; set; }
        [NotMapped]
        public string title { get; set; }
        [NotMapped]
        public string start { get; set; }
        [NotMapped]
        public string end { get; set; }
    }
}
