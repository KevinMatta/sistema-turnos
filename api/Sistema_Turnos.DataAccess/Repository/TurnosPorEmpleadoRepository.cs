using Dapper;
using Microsoft.Data.SqlClient;
using Sistema_Turnos.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_Turnos.DataAccess.Repository
{
    public class TurnosPorEmpleadoRepository : IRepository<tbTurnosPorEmpleados>
    {
        public RequestStatus Delete(int? id)
        {
            string sql = ScriptsBaseDeDatos.TuEm_Eliminar;
            using (var db = new SqlConnection(Sistemas_TurnosContext.ConnectionString))
            {
                var parametro = new DynamicParameters();
                parametro.Add("@TuEm_Id", id);

                var result = db.Execute(
                    sql, parametro,
                    commandType: CommandType.StoredProcedure
                );

                string mensaje = (result == 1) ? "exito" : "error";

                return new RequestStatus { CodeStatus = result, MessageStatus = mensaje };

            };
        }

        public tbTurnosPorEmpleados Details(int? id)
        {
            throw new NotImplementedException();
        }

        public tbTurnosPorEmpleados find(int? id)
        {
            string sql = ScriptsBaseDeDatos.TuEm_Buscar;
            using (var db = new SqlConnection(Sistemas_TurnosContext.ConnectionString))
            {
                var parameters = new {TuEm_Id = id};
                return db.QueryFirstOrDefault<tbTurnosPorEmpleados>(sql, parameters, commandType: CommandType.StoredProcedure);  
            }
        }

        public RequestStatus Insert(tbTurnosPorEmpleados item)
        {
            string sql = ScriptsBaseDeDatos.TuEm_Crear;

            using (var db = new SqlConnection(Sistemas_TurnosContext.ConnectionString))
            {
                var parameter = new DynamicParameters();
                parameter.Add("@TuEm_FechaInicio", item.TuEm_FechaInicio);
                parameter.Add("@Turn_Id", item.Turn_Id);
                parameter.Add("@Empl_Id", item.Empl_Id);
                parameter.Add("@TuEm_Creacion", item.TuEm_Creacion);
                parameter.Add("@TuEm_FechaCreacion", item.TuEm_FechaCreacion);

                var result = db.Execute(sql, parameter, commandType: CommandType.StoredProcedure);
                string mensaje = (result == 1) ? "exito" : "error";
                return new RequestStatus { CodeStatus = result, MessageStatus = mensaje };
            }
        }

        public IEnumerable<tbTurnosPorEmpleados> List()
        {
            string sql = ScriptsBaseDeDatos.TuEm_Listar;

            List<tbTurnosPorEmpleados> result = new List<tbTurnosPorEmpleados>();

            using (var db = new SqlConnection(Sistemas_TurnosContext.ConnectionString))
            {
                result = db.Query<tbTurnosPorEmpleados>(sql, commandType: CommandType.Text).ToList();

                return result;
            }
        }

        public RequestStatus Update(tbTurnosPorEmpleados item)
        {
            string sql = ScriptsBaseDeDatos.TuEm_Editar;

            using (var db = new SqlConnection(Sistemas_TurnosContext.ConnectionString))
            {
                var parameter = new DynamicParameters();
                parameter.Add("@TuEm_Id", item.TuEm_Id);
                parameter.Add("@TuEm_FechaInicio", item.TuEm_FechaInicio);
                parameter.Add("@Turn_Id", item.Turn_Id);
                parameter.Add("@Empl_Id", item.Empl_Id);
                parameter.Add("@TuEm_Modificacion", item.TuEm_Modificacion);
                parameter.Add("@TuEm_FechaModificacion", item.TuEm_FechaModificacion);

                var result = db.Execute(sql, parameter, commandType: CommandType.StoredProcedure);
                string mensaje = (result == 1) ? "exito" : "error";
                return new RequestStatus { CodeStatus = result, MessageStatus = mensaje };

            }
        }
    }
}
