using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_Turnos.Common.Models
{
    public class MunicipioViewModel
    {
        public string Ciud_Id { get; set; }
        public string Ciud_Descripcion { get; set; }
        public string Esta_Id { get; set; }
        public bool? Ciud_Estado { get; set; }
        public int Ciud_Creacion { get; set; }
        public DateTime Ciud_FechaCreacion { get; set; }
        public int? Ciud_Modificacion { get; set; }
        public DateTime? Ciud_FechaModificacion { get; set; }

        [NotMapped]
        public string usua_creac { get; set; }

        [NotMapped]
        public string usua_modi { get; set; }

        [NotMapped]
        public string Esta_Descripcion { get; set; }
    }
}
