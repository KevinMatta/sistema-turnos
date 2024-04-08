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
    }
}
