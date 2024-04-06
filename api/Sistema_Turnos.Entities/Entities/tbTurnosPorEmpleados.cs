﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace Sistema_Turnos.Entities.Entities
{
    public partial class tbTurnosPorEmpleados
    {
        public int TuEm_Id { get; set; }
        public DateTime TuEm_FechaInicio { get; set; }
        public int Turn_Id { get; set; }
        public int Empl_Id { get; set; }
        public bool? TuEm_Estado { get; set; }
        public int TuEm_Creacion { get; set; }
        public DateTime TuEm_FechaCreacion { get; set; }
        public int? TuEm_Modificacion { get; set; }
        public DateTime? TuEm_FechaModificacion { get; set; }

        //campos extras
        [NotMapped]
        public string title { get; set; }
        [NotMapped]
        public string start { get; set; }

        public virtual tbEmpleados Empl { get; set; }
        public virtual tbUsuarios TuEm_CreacionNavigation { get; set; }
        public virtual tbUsuarios TuEm_ModificacionNavigation { get; set; }
        public virtual tbTurnos Turn { get; set; }
    }
}