using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_Turnos.Common.Models
{
    public class PantallaViewModel
    {
        public int Pant_Id { get; set; }
        public string Pant_Descripcion { get; set; }
        public int Pant_Creacion { get; set; }
        public DateTime Pant_FechaCreacion { get; set; }
        public int? Pant_Modificacion { get; set; }
        public DateTime? Pant_FechaModificacion { get; set; }

        [NotMapped]
        public List<int> PantallasID { get; set; }

        [NotMapped]
        public int numero { get; set; }

    }
}
