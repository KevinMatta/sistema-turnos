﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;

#nullable disable

namespace Sistema_Turnos.Entities.Entities
{
    public partial class tbTurnos
    {
        public tbTurnos()
        {
            tbTurnosPorEmpleados = new HashSet<tbTurnosPorEmpleados>();
        }

        public int Turn_Id { get; set; }
        public string Turn_Descripcion { get; set; }
        public TimeSpan Turn_HoraEntrada { get; set; }
        public bool? Turn_Estado { get; set; }
        public int Turn_Creacion { get; set; }
        public DateTime Turn_FechaCreacion { get; set; }
        public int? Turn_Modificacion { get; set; }
        public DateTime? Turn_FechaModificacion { get; set; }
        public TimeSpan? Turn_HoraSalida { get; set; }

        public virtual tbUsuarios Turn_CreacionNavigation { get; set; }
        public virtual tbUsuarios Turn_ModificacionNavigation { get; set; }
        public virtual ICollection<tbTurnosPorEmpleados> tbTurnosPorEmpleados { get; set; }
    }
}