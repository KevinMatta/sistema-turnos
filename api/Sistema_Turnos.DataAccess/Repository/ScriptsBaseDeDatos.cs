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

        #region Estados
        public static string Estad_Insertar = "[Gene].[sp_Estados_crear]";
            public static string Estad_Listar = "[Gene].[sp_Estados_listar]";
            public static string Estad_Eliminar = "[Gene].[sp_Estados_eliminar]";
            public static string Estad_Actualizar = "[Gene].[sp_Estados_editar]";
            public static string Estad_Obtener = "[Gene].[sp_Estados_obtener]";
            public static string Estad_Llenar = "[Gene].[sp_Estados_llenar]";
            #endregion

        #endregion

        #region Turnos

            #region TurnosPorEmpleado
            public static string TuEm_Listar = "[Turn].[sp_TurnosPorEmpleados_listar]";
            #endregion

        #endregion
    }
}
