using System;
using System.Collections.Generic;
using System.Text;

namespace Sistema_Turnos.DataAccess.Repository
{
    public class ScriptsBaseDeDatos
    {
        #region Estados
        public static string Estad_Insertar = "[Gene].[sp_Estados_crear]";
        public static string Estad_Listar = "[Gene].[sp_Estados_listar]";
        public static string Estad_Eliminar = "[Gene].[sp_Estados_eliminar]";
        public static string Estad_Actualizar = "[Gene].[sp_Estados_editar]";
        public static string Estad_Obtener = "[Gene].[sp_Estados_obtener]";
        public static string Estad_Llenar = "[Gene].[sp_Estados_llenar]";
        #endregion

        #region TurnosPorEmpleado
        public static string TuEm_Listar = "[Turn].[sp_TurnosPorEmpleados_listar]";
        public static string TuEm_Buscar = "[Turn].[sp_TurnosPorEmpleados_buscar]";
        public static string TuEm_Crear = "[Turn].[sp_TurnosPorEmpleados_crear]";
        public static string TuEm_Editar = "[Turn].[sp_TurnosPorEmpleados_editar]";
        public static string TuEm_Eliminar = "[Turn].[sp_TurnosPorEmpleados_eliminar]";
        #endregion

    }
}
