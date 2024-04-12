using Sistema_Turnos.Entities.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_Turnos.Common.Models
{
    public class DepartamentoViewModel
    {
        public string Esta_Id { get; set; }
        public string Esta_Descripcion { get; set; }
        public int Esta_Creacion { get; set; }
        public DateTime Esta_FechaCreacion { get; set; }
        public int? Esta_Modificacion { get; set; }
        public DateTime? Esta_FechaModificacion { get; set; }

        [NotMapped]
        public string usua_creac { get; set; }

        [NotMapped]
        public string usua_modi { get; set; }
        [NotMapped]
        public ICollection<tbCiudades> tbCiudades { get; set; }
    }
}
