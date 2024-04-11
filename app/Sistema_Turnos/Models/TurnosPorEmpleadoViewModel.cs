using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Sistema_Turnos.Models
{
    public class TurnosPorEmpleadoViewModel
    {
        [Display(Name = "Id")]
        public int TuEm_Id { get; set; }
        [Display(Name = "Fecha Inicio")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public DateTime TuEm_FechaInicio { get; set; }
        [Display(Name = "Turno Id")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public int Turn_Id { get; set; }
        [Display(Name = "Empleado")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "El campo {0} solo acepta números.")]
        public int Empl_Id { get; set; }
        public string TuEm_HoraEntrada { get; set; }
        public string TuEm_HoraSalida { get; set; }
        [Display(Name = "Estado")]
        public bool? TuEm_Estado { get; set; }
        [Display(Name = "Usuario Creacion")]
        public int TuEm_Creacion { get; set; }
        [Display(Name = "Fecha Creacion")]
        public DateTime TuEm_FechaCreacion { get; set; }
        [Display(Name = "Usuario Modificacion")]
        public int? TuEm_Modificacion { get; set; }
        [Display(Name = "Fecha Modificacion")]
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
