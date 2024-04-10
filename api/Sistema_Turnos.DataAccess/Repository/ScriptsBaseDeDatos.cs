using System;
using System.Collections.Generic;
using System.Text;

namespace Sistema_Turnos.DataAccess.Repository
{
    public class ScriptsBaseDeDatos
    {
        #region Acceso

                #region Roles

                public static string Rol_Insertar = "[Acce].[sp_Roles_crear]";
                public static string Rol_Listar = "[Acce].[sp_Roles_listar]";
                public static string Rol_Eliminar = "[Acce].[sp_Roles_eliminar]";
                public static string Rol_Actualizar = "[Acce].[sp_Roles_editar]";
                public static string Rol_Obtener = "[Acce].[sp_Roles_obtener]";
                public static string Rol_Llenar = "[Gene].[sp_Estados_llenar]";
                public static string Rol_ObtenerId = "Acce.sp_Roles_obtenerid";
                public static string Rol_Obtener_Rol = "[Acce].[sp_Roles_obtener_rol]";
                public static string Validar_Url = "Acce.sp_ValidarUrl";

                #endregion

                #region PantallasPorRoles
                public static string PanRo_Insertar = "[Acce].[sp_PantallasPorRol_crear]";
                public static string PanRo_Buscar = "[Acce].[sp_PantallasPorRol_buscar]";
                public static string PanRo_Eliminar = "[Acce].[sp_PantallasPorRol_eliminar]";
                #endregion

                #region Pantallas

                public static string Panta_Listar = "[Acce].[sp_Pantallas_listar]";

                #endregion

                #region Usuario
                public static string Usua_Login = "[Acce].[SP_Usuarios_InicioSesion]";
                public static string Usua_usuario = "Acce.sp_Usuarios_validarusuario";
                public static string Usua_clave = "Acce.sp_Usuarios_validarclave";
            #endregion

        #endregion

        #region General

                #region Departamentos
                public static string Estad_Insertar = "[Gene].[sp_Estados_crear]";
                public static string Estad_Listar = "[Gene].[sp_Estados_listar]";
                public static string Estad_Eliminar = "[Gene].[sp_Estados_eliminar]";
                public static string Estad_Actualizar = "[Gene].[sp_Estados_editar]";
                public static string Estad_Obtener = "[Gene].[sp_Estados_obtener]";
                public static string Estad_Llenar = "[Gene].[sp_Estados_llenar]";
                public static string Estad_ObtenerEstado = "[Gene].[sp_Estados_obtener_estado]";
                #endregion

                #region Municipios
                public static string Munic_Insertar = "[Gene].[sp_Ciudades_crear]";
                public static string Munic_Listar = "[Gene].[sp_Ciudades_listar]";
                public static string Munic_Eliminar = "[Gene].[sp_Ciudades_eliminar]";
                public static string Munic_Actualizar = "[Gene].[sp_Ciudades_editar]";
                public static string Munic_Obtener = "[Gene].[sp_Ciudades_obtener]";
                //public static string Munic_Llenar = "[Gene].[sp_Estados_llenar]";
                //public static string Munic_ObtenerEstado = "[Gene].[sp_Estados_obtener_estado]";
                #endregion

                #region Cargos
                public static string Cargo_Insertar = "[Gene].[sp_Cargos_crear]";
                public static string Cargo_Listar = "[Gene].[sp_Cargos_listar]";
                public static string Cargo_Eliminar = "[Gene].[sp_Cargos_eliminar]";
                public static string Cargo_Actualizar = "[Gene].[sp_Cargos_editar]";
                public static string Cargo_Obtener = "[Gene].[sp_Cargos_obtener]";
                //public static string Munic_Llenar = "[Gene].[sp_Estados_llenar]";
                //public static string Munic_ObtenerEstado = "[Gene].[sp_Estados_obtener_estado]";
                #endregion

                #region EstadosCiviles
                public static string Estci_Insertar = "[Gene].[sp_EstadosCiviles_crear]";
                public static string Estci_Listar = "[Gene].[sp_EstadosCiviles_listar]";
                public static string Estci_Eliminar = "[Gene].[sp_EstadosCiviles_eliminar]";
                public static string Estci_Actualizar = "[Gene].[sp_EstadosCiviles_editar]";
                public static string Estci_Obtener = "[Gene].[sp_EstadosCiviles_obtener]";
                //public static string Munic_Llenar = "[Gene].[sp_Estados_llenar]";
                //public static string Munic_ObtenerEstado = "[Gene].[sp_Estados_obtener_estado]";
                #endregion

                #region Personas
                public static string Person_Insertar = "[Gene].[sp_Personas_crear]";
                public static string Person_Listar = "[Gene].[sp_Personas_listar]";
                public static string Person_Eliminar = "[Gene].[sp_Personas_eliminar]";
                public static string Person_Actualizar = "[Gene].[sp_Personas_editar]";
                public static string Person_Obtener = "[Gene].[sp_Personas_obtener]";
                //public static string Munic_Llenar = "[Gene].[sp_Estados_llenar]";
                //public static string Munic_ObtenerEstado = "[Gene].[sp_Estados_obtener_estado]";
                #endregion

        #endregion

        #region Turnos

                #region TurnosPorEmpleado
                public static string TuEm_Listar = "[Turn].[sp_TurnosPorEmpleados_listar]";
                #endregion

                #region Empleados
                public static string Emple_Insertar = "[Turn].[sp_Empleados_crear]";
                public static string Emple_Listar = "[Turn].[sp_Empleados_listar]";
                public static string Emple_Eliminar = "[Turn].[sp_Empleados_eliminar]";
                public static string Emple_Actualizar = "[Turn].[sp_Empleados_editar]";
                public static string Emple_Obtener = "[Turn].[sp_Empleados_buscar] ";
                //public static string Munic_Llenar = "[Gene].[sp_Estados_llenar]";
                //public static string Munic_ObtenerEstado = "[Gene].[sp_Estados_obtener_estado]";
        #endregion

                #region Hospitales
                public static string Hospi_Insertar = "[Turn].[sp_Hospitales_crear]";
                public static string Hospi_Listar = "[Turn].[sp_Empleados_listar]";
                public static string Hospi_Eliminar = "[Turn].[sp_Hospitales_eliminar]";
                public static string Hospi_Actualizar = "[Turn].[sp_Hospitales_editar]";
                public static string Hospi_Obtener = "[Turn].[sp_Empleados_buscar] ";
                //public static string Munic_Llenar = "[Gene].[sp_Estados_llenar]";
                //public static string Munic_ObtenerEstado = "[Gene].[sp_Estados_obtener_estado]";
        #endregion

                #region Hospitales
                public static string Turno_Insertar = "[Turn].[sp_Turnos_crear]";
                public static string Turno_Listar = "[Turn].[sp_Turnos_listar]";
                public static string Turno_Eliminar = "[Turn].[sp_Turnos_eliminar]";
                public static string Turno_Actualizar = "[Turn].[sp_Turnos_editar]";
                public static string Turno_Obtener = "[Turn].[sp_Turnos_buscar]  ";
                //public static string Munic_Llenar = "[Gene].[sp_Estados_llenar]";
                //public static string Munic_ObtenerEstado = "[Gene].[sp_Estados_obtener_estado]";
                #endregion

        #endregion
    }
}
