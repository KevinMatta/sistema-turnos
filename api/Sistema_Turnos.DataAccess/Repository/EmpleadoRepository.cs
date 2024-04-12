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
    public class EmpleadoRepository : IRepository<tbEmpleados>
    {
        public RequestStatus Delete(tbEmpleados item)
        {
            throw new NotImplementedException();
        }

        public RequestStatus EliminarEmpleados(int id, int usuario, DateTime fecha)
        {
            string sql = ScriptsBaseDeDatos.Empl_Eliminar;
            using (var db = new SqlConnection(Sistemas_TurnosContext.ConnectionString))
            {
                var parametro = new DynamicParameters();
                parametro.Add("@Empl_Id", id);
                parametro.Add("@Empl_Modificacion", usuario);
                parametro.Add("@Empl_FechaModificacion", fecha);

                var result = db.Execute(
                    sql, parametro,
                    commandType: CommandType.StoredProcedure
                );

                string mensaje = (result == 1) ? "exito" : "error";

                return new RequestStatus { CodeStatus = result, MessageStatus = mensaje };

            };
        }

        public tbEmpleados Details(int? id)
        {
            throw new NotImplementedException();
        }

        public tbEmpleados find(int? id)
        {
            throw new NotImplementedException();
        }

        public RequestStatus Insert(tbEmpleados item)
        {
            string sql = ScriptsBaseDeDatos.Empl_Insertar;

            using (var db = new SqlConnection(Sistemas_TurnosContext.ConnectionString))
            {
                var parameter = new DynamicParameters();
                parameter.Add("@Pers_Identidad", item.Pers_Identidad);
                parameter.Add("@Usua_Id", item.Usua_Id);
                parameter.Add("@Carg_Id", item.Carg_Id);
                parameter.Add("@Hosp_Id", item.Hosp_Id);
                parameter.Add("@Empl_Creacion", item.Empl_Creacion);
                parameter.Add("@Empl_FechaCreacion", item.Empl_FechaCreacion);

                var result = db.Execute(sql, parameter, commandType: CommandType.StoredProcedure);
                string mensaje = (result == 1) ? "exito" : "error";
                return new RequestStatus { CodeStatus = result, MessageStatus = mensaje };

                //var result = db.QueryFirst(sql, parameter, commandType: CommandType.Text);

                //return result;
            }
        }

        public IEnumerable<tbEmpleados> List()
        {
            string sql = ScriptsBaseDeDatos.Empl_Listar;

            List<tbEmpleados> result = new List<tbEmpleados>();

            using (var db = new SqlConnection(Sistemas_TurnosContext.ConnectionString))
            {
                result = db.Query<tbEmpleados>(sql, commandType: CommandType.Text).ToList();

                return result;
            }
        }

        public IEnumerable<tbEmpleados> List(int Empl_Id)
        {
            string sql = ScriptsBaseDeDatos.Empl_Obtener;

            List<tbEmpleados> result = new List<tbEmpleados>();

            using (var db = new SqlConnection(Sistemas_TurnosContext.ConnectionString))
            {
                var parameters = new { Empl_Id };
                result = db.Query<tbEmpleados>(sql, parameters, commandType: CommandType.StoredProcedure).ToList();
                return result;
            }
        }

        public IEnumerable<tbEmpleados> ObtenerEmple(int Empl_Id)
        {
            string sql = ScriptsBaseDeDatos.Empl_Traer_Emple;

            List<tbEmpleados> result = new List<tbEmpleados>();

            using (var db = new SqlConnection(Sistemas_TurnosContext.ConnectionString))
            {
                var parameters = new { Empl_Id };
                result = db.Query<tbEmpleados>(sql, parameters, commandType: CommandType.StoredProcedure).ToList();
                return result;
            }
        }

        public RequestStatus Update(tbEmpleados item)
        {
            string sql = ScriptsBaseDeDatos.Empl_Actualizar;

            using (var db = new SqlConnection(Sistemas_TurnosContext.ConnectionString))
            {
                var parameter = new DynamicParameters();
                parameter.Add("@Empl_Id", item.Empl_Id);
                parameter.Add("@Pers_Identidad", item.Pers_Identidad);
                parameter.Add("@Usua_Id", item.Usua_Id);
                parameter.Add("@Carg_Id", item.Carg_Id);
                parameter.Add("@Hosp_Id", item.Hosp_Id);
                parameter.Add("@Empl_Modificacion", item.Empl_Modificacion);
                parameter.Add("@Empl_FechaModificacion", item.Empl_FechaModificacion);

                var result = db.Execute(sql, parameter, commandType: CommandType.StoredProcedure);
                string mensaje = (result == 1) ? "exito" : "error";
                return new RequestStatus { CodeStatus = result, MessageStatus = mensaje };

            }
        }
    }
}
