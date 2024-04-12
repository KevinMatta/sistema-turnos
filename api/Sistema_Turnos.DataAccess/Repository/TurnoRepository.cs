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
    public class TurnoRepository : IRepository<tbTurnos>
    {

        public RequestStatus Delete(tbTurnos item)
        {
            throw new NotImplementedException();
        }

        public RequestStatus EliminarTurnos(int id, int usuario, DateTime fecha)
        {
            string sql = ScriptsBaseDeDatos.Turn_Eliminar;
            using (var db = new SqlConnection(Sistemas_TurnosContext.ConnectionString))
            {
                var parametro = new DynamicParameters();
                parametro.Add("@Turn_Id", id);
                parametro.Add("@Turn_Modificacion", usuario);
                parametro.Add("@Turn_FechaModificacion", fecha);

                var result = db.Execute(
                    sql, parametro,
                    commandType: CommandType.StoredProcedure
                );

                string mensaje = (result == 1) ? "exito" : "error";

                return new RequestStatus { CodeStatus = result, MessageStatus = mensaje };

            };
        }

        public tbTurnos Details(int? id)
        {
            throw new NotImplementedException();
        }

        public tbTurnos find(int? id)
        {
            throw new NotImplementedException();
        }

        public RequestStatus Insert(tbTurnos item)
        {
             string sql = ScriptsBaseDeDatos.Turn_Insertar;

                using (var db = new SqlConnection(Sistemas_TurnosContext.ConnectionString))
                {
                    var parameter = new DynamicParameters();
                    parameter.Add("@Turn_Descripcion", item.Turn_Descripcion);
                    parameter.Add("@Turn_HoraEntrada", item.Turn_HoraEntrada);
                    parameter.Add("@Turn_HoraSalida", item.Turn_HoraSalida);
                    parameter.Add("@Turn_Creacion", item.Turn_Creacion);
                    parameter.Add("@Turn_FechaCreacion", item.Turn_FechaCreacion);

                    var result = db.Execute(sql, parameter, commandType: CommandType.StoredProcedure);
                    string mensaje = (result == 1) ? "exito" : "error";
                    return new RequestStatus { CodeStatus = result, MessageStatus = mensaje };

                    //var result = db.QueryFirst(sql, parameter, commandType: CommandType.Text);

                    //return result;
                }
        }

        public IEnumerable<tbTurnos> List()
        {
            string sql = ScriptsBaseDeDatos.Turn_Listar;

            List<tbTurnos> result = new List<tbTurnos>();

            using (var db = new SqlConnection(Sistemas_TurnosContext.ConnectionString))
            {
                result = db.Query<tbTurnos>(sql, commandType: CommandType.Text).ToList();

                return result;
            }
        }

        public IEnumerable<tbTurnos> List(int Turn_Id)
        {
            string sql = ScriptsBaseDeDatos.Turn_Obtener;

            List<tbTurnos> result = new List<tbTurnos>();

            using (var db = new SqlConnection(Sistemas_TurnosContext.ConnectionString))
            {
                var parameters = new { Turn_Id };
                result = db.Query<tbTurnos>(sql, parameters, commandType: CommandType.StoredProcedure).ToList();
                return result;
            }
        }

        public RequestStatus Update(tbTurnos item)
        {
            string sql = ScriptsBaseDeDatos.Turn_Actualizar;

            using (var db = new SqlConnection(Sistemas_TurnosContext.ConnectionString))
            {
                var parameter = new DynamicParameters();
                parameter.Add("@Turn_Id", item.Turn_Id);
                parameter.Add("@Turn_Descripcion", item.Turn_Descripcion);
                parameter.Add("@Turn_HoraEntrada", item.Turn_HoraEntrada);
                parameter.Add("@Turn_HoraSalida", item.Turn_HoraSalida);
                parameter.Add("@Turn_Modificacion", item.Turn_Modificacion);
                parameter.Add("@Turn_FechaModificacion", item.Turn_FechaModificacion);

                var result = db.Execute(sql, parameter, commandType: CommandType.StoredProcedure);
                string mensaje = (result == 1) ? "exito" : "error";
                return new RequestStatus { CodeStatus = result, MessageStatus = mensaje };

                //var result = db.QueryFirst(sql, parameter, commandType: CommandType.Text);

                //return result;
            }
        }
    }
}
