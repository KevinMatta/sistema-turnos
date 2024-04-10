﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_Turnos.Common.Models
{
    public class CargoViewModel
    {
        public int Carg_Id { get; set; }
        public string Carg_Descripcion { get; set; }
        public bool? Carg_Estado { get; set; }
        public int Carg_Creacion { get; set; }
        public DateTime Carg_FechaCreacion { get; set; }
        public int? Carg_Modificacion { get; set; }
        public DateTime? Carg_FechaModificacion { get; set; }

        [NotMapped]
        public string usua_creac { get; set; }

        [NotMapped]
        public string usua_modi { get; set; }
    }
}
