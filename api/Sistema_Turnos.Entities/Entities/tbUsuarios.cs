﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace Sistema_Turnos.Entities.Entities
{
    public partial class tbUsuarios
    {
        public tbUsuarios()
        {
            InverseUsua_CreacionNavigation = new HashSet<tbUsuarios>();
            InverseUsua_ModificacionNavigation = new HashSet<tbUsuarios>();
            tbCargosCarg_CreacionNavigation = new HashSet<tbCargos>();
            tbCargosCarg_ModificacionNavigation = new HashSet<tbCargos>();
            tbCiudadesCiud_CreacionNavigation = new HashSet<tbCiudades>();
            tbCiudadesCiud_ModificacionNavigation = new HashSet<tbCiudades>();
            tbEmpleadosEmpl_CreacionNavigation = new HashSet<tbEmpleados>();
            tbEmpleadosEmpl_ModificacionNavigation = new HashSet<tbEmpleados>();
            tbEstadosCivilesEsCi_CreacionNavigation = new HashSet<tbEstadosCiviles>();
            tbEstadosCivilesEsCi_ModificacionNavigation = new HashSet<tbEstadosCiviles>();
            tbEstadosEsta_CreacionNavigation = new HashSet<tbEstados>();
            tbEstadosEsta_ModificacionNavigation = new HashSet<tbEstados>();
            tbHospitalesHosp_CreacionNavigation = new HashSet<tbHospitales>();
            tbHospitalesHosp_ModificacionNavigation = new HashSet<tbHospitales>();
            tbPantallasPant_CreacionNavigation = new HashSet<tbPantallas>();
            tbPantallasPant_ModificacionNavigation = new HashSet<tbPantallas>();
            tbPantallasPorRolesPaRo_CreacionNavigation = new HashSet<tbPantallasPorRoles>();
            tbPantallasPorRolesPaRo_ModificacionNavigation = new HashSet<tbPantallasPorRoles>();
            tbPersonasPers_CreacionNavigation = new HashSet<tbPersonas>();
            tbPersonasPers_ModificacionNavigation = new HashSet<tbPersonas>();
            tbRolesRol_CreacionNavigation = new HashSet<tbRoles>();
            tbRolesRol_ModificacionNavigation = new HashSet<tbRoles>();
            tbTurnosPorEmpleadosTuEm_CreacionNavigation = new HashSet<tbTurnosPorEmpleados>();
            tbTurnosPorEmpleadosTuEm_ModificacionNavigation = new HashSet<tbTurnosPorEmpleados>();
            tbTurnosTurn_CreacionNavigation = new HashSet<tbTurnos>();
            tbTurnosTurn_ModificacionNavigation = new HashSet<tbTurnos>();
        }

        public int Usua_Id { get; set; }
        public string Usua_Usuario { get; set; }
        public byte[] Usua_Clave { get; set; }
        public int? Rol_Id { get; set; }
        public bool? Usua_IsAdmin { get; set; }
        public bool? Usua_Estado { get; set; }
        public int Usua_Creacion { get; set; }
        public DateTime Usua_FechaCreacion { get; set; }
        public int? Usua_Modificacion { get; set; }
        public DateTime? Usua_FechaModificacion { get; set; }

        [NotMapped]
        public string Usua_Nombre { get; set; }

        [NotMapped]
        public byte[] Usua_Contrasenia { get; set; }

        [NotMapped]
        public string Usua_Administrador { get; set; }

        [NotMapped]
        public string Pant_Descripcion { get; set; }

        public virtual tbUsuarios Usua_CreacionNavigation { get; set; }
        public virtual tbUsuarios Usua_ModificacionNavigation { get; set; }
        public virtual ICollection<tbUsuarios> InverseUsua_CreacionNavigation { get; set; }
        public virtual ICollection<tbUsuarios> InverseUsua_ModificacionNavigation { get; set; }
        public virtual ICollection<tbCargos> tbCargosCarg_CreacionNavigation { get; set; }
        public virtual ICollection<tbCargos> tbCargosCarg_ModificacionNavigation { get; set; }
        public virtual ICollection<tbCiudades> tbCiudadesCiud_CreacionNavigation { get; set; }
        public virtual ICollection<tbCiudades> tbCiudadesCiud_ModificacionNavigation { get; set; }
        public virtual ICollection<tbEmpleados> tbEmpleadosEmpl_CreacionNavigation { get; set; }
        public virtual ICollection<tbEmpleados> tbEmpleadosEmpl_ModificacionNavigation { get; set; }
        public virtual ICollection<tbEstadosCiviles> tbEstadosCivilesEsCi_CreacionNavigation { get; set; }
        public virtual ICollection<tbEstadosCiviles> tbEstadosCivilesEsCi_ModificacionNavigation { get; set; }
        public virtual ICollection<tbEstados> tbEstadosEsta_CreacionNavigation { get; set; }
        public virtual ICollection<tbEstados> tbEstadosEsta_ModificacionNavigation { get; set; }
        public virtual ICollection<tbHospitales> tbHospitalesHosp_CreacionNavigation { get; set; }
        public virtual ICollection<tbHospitales> tbHospitalesHosp_ModificacionNavigation { get; set; }
        public virtual ICollection<tbPantallas> tbPantallasPant_CreacionNavigation { get; set; }
        public virtual ICollection<tbPantallas> tbPantallasPant_ModificacionNavigation { get; set; }
        public virtual ICollection<tbPantallasPorRoles> tbPantallasPorRolesPaRo_CreacionNavigation { get; set; }
        public virtual ICollection<tbPantallasPorRoles> tbPantallasPorRolesPaRo_ModificacionNavigation { get; set; }
        public virtual ICollection<tbPersonas> tbPersonasPers_CreacionNavigation { get; set; }
        public virtual ICollection<tbPersonas> tbPersonasPers_ModificacionNavigation { get; set; }
        public virtual ICollection<tbRoles> tbRolesRol_CreacionNavigation { get; set; }
        public virtual ICollection<tbRoles> tbRolesRol_ModificacionNavigation { get; set; }
        public virtual ICollection<tbTurnosPorEmpleados> tbTurnosPorEmpleadosTuEm_CreacionNavigation { get; set; }
        public virtual ICollection<tbTurnosPorEmpleados> tbTurnosPorEmpleadosTuEm_ModificacionNavigation { get; set; }
        public virtual ICollection<tbTurnos> tbTurnosTurn_CreacionNavigation { get; set; }
        public virtual ICollection<tbTurnos> tbTurnosTurn_ModificacionNavigation { get; set; }
    }
}