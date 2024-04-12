using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Sistema_Turnos.Models
{
    public class TurnoViewModel
    {
        [Display(Name = "ID")]
        public int Turn_Id { get; set; }
        [Display(Name = "Turno")]
        public string Turn_Descripcion { get; set; }
        [Display(Name = "Hora-Entrada")]
        public string Turn_HoraEntrada { get; set; }
        public bool? Turn_Estado { get; set; }
        public int Turn_Creacion { get; set; }
        public DateTime Turn_FechaCreacion { get; set; }
        public int? Turn_Modificacion { get; set; }
        public DateTime? Turn_FechaModificacion { get; set; }
        
        [Display(Name = "Hora-Salida")]
        public string Turn_HoraSalida { get; set; }

        [NotMapped]
        public string usua_creac { get; set; }

        [NotMapped]
        public string usua_modi { get; set; }

    }
}
