﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace Sistema_Turnos.Entities.Entities
{
    public partial class tbHospitales
    {
        public tbHospitales()
        {
            tbEmpleados = new HashSet<tbEmpleados>();
        }

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

        public virtual tbCiudades Ciud { get; set; }
        public virtual tbEstados Esta { get; set; }
        public virtual tbUsuarios Hosp_CreacionNavigation { get; set; }
        public virtual tbUsuarios Hosp_ModificacionNavigation { get; set; }
        public virtual ICollection<tbEmpleados> tbEmpleados { get; set; }
    }
}