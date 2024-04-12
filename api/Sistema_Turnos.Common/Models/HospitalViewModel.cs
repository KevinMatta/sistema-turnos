using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_Turnos.Common.Models
{
    public class HospitalViewModel
    {
        public int Hosp_Id { get; set; }
        public string Hosp_Descripcion { get; set; }
        public string Hosp_Direccion { get; set; }
        public string Ciud_Id { get; set; }
        public bool? Hosp_Estado { get; set; }
        public int Hosp_Creacion { get; set; }
        public DateTime Hosp_FechaCreacion { get; set; }
        public int? Hosp_Modificacion { get; set; }
        public DateTime? Hosp_FechaModificacion { get; set; }
        public string Esta_Id { get; set; }

        [NotMapped]
        public string Ciud_Descripcion { get; set; }

        [NotMapped]
        public string Esta_Descripcion { get; set; }

        [NotMapped]
        public string usua_creac { get; set; }

        [NotMapped]
        public string usua_modi { get; set; }
    }
}
