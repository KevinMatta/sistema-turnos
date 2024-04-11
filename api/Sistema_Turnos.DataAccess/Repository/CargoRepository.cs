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
    public class CargoRepository : IRepository<tbCargos>
    {
        public RequestStatus Delete(tbCargos item)
        {
            throw new NotImplementedException();
        }

        public RequestStatus EliminarCargo(int id, int usuario, DateTime fecha)
        {
            string sql = ScriptsBaseDeDatos.Cargo_Eliminar;
            using (var db = new SqlConnection(Sistemas_TurnosContext.ConnectionString))
            {
                var parametro = new DynamicParameters();
                parametro.Add("@Carg_Id", id);
                parametro.Add("@Carg_Modificacion", usuario);
                parametro.Add("@Carg_FechaModificacion", fecha);

                var result = db.Execute(
                    sql, parametro,
                    commandType: CommandType.StoredProcedure
                );

                string mensaje = (result == 1) ? "exito" : "error";

                return new RequestStatus { CodeStatus = result, MessageStatus = mensaje };

            };
        }

        public tbCargos Details(int? id)
        {
            throw new NotImplementedException();
        }

        public tbCargos find(int? id)
        {
            throw new NotImplementedException();
        }

        public RequestStatus Insert(tbCargos item)
        {
            string sql = ScriptsBaseDeDatos.Cargo_Insertar;

            using (var db = new SqlConnection(Sistemas_TurnosContext.ConnectionString))
            {
                var parameter = new DynamicParameters();
                parameter.Add("@Carg_Descripcion", item.Carg_Descripcion);
                parameter.Add("@Carg_Creacion", item.Carg_Creacion);
                parameter.Add("@Carg_FechaCreacion", item.Carg_FechaCreacion);

                var result = db.Execute(sql, parameter, commandType: CommandType.StoredProcedure);
                string mensaje = (result == 1) ? "exito" : "error";
                return new RequestStatus { CodeStatus = result, MessageStatus = mensaje };

                //var result = db.QueryFirst(sql, parameter, commandType: CommandType.Text);

                //return result;
            }
        }

        public IEnumerable<tbCargos> List()
        {
            string sql = ScriptsBaseDeDatos.Cargo_Listar;

            List<tbCargos> result = new List<tbCargos>();

            using (var db = new SqlConnection(Sistemas_TurnosContext.ConnectionString))
            {
                result = db.Query<tbCargos>(sql, commandType: CommandType.Text).ToList();

                return result;
            }
        }

        public IEnumerable<tbCargos> List(int Carg_Id)
        {
            string sql = ScriptsBaseDeDatos.Cargo_Obtener;

            List<tbCargos> result = new List<tbCargos>();

            using (var db = new SqlConnection(Sistemas_TurnosContext.ConnectionString))
            {
                var parameters = new { Carg_Id };
                result = db.Query<tbCargos>(sql, parameters, commandType: CommandType.StoredProcedure).ToList();
                return result;
            }
        }

        public RequestStatus Update(tbCargos item)
        {
            string sql = ScriptsBaseDeDatos.Cargo_Actualizar;

            using (var db = new SqlConnection(Sistemas_TurnosContext.ConnectionString))
            {
                var parameter = new DynamicParameters();
                parameter.Add("@Carg_Id", item.Carg_Id);
                parameter.Add("@Carg_Descripcion", item.Carg_Descripcion);
                parameter.Add("@Carg_Modificacion", item.Carg_Modificacion);
                parameter.Add("@Carg_FechaModificacion", item.Carg_FechaModificacion);

                var result = db.Execute(sql, parameter, commandType: CommandType.StoredProcedure);
                string mensaje = (result == 1) ? "exito" : "error";
                return new RequestStatus { CodeStatus = result, MessageStatus = mensaje };

            }
        }
    }
}
