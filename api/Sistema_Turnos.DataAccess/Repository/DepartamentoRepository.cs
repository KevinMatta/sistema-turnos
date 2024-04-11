using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using Dapper;
using Microsoft.Data.SqlClient;
using Sistema_Turnos.Entities.Entities;

namespace Sistema_Turnos.DataAccess.Repository
{
    public class DepartamentoRepository : IRepository<tbEstados>
    {
        public RequestStatus Delete(int? id)
        {
            throw new NotImplementedException();
        }

        public RequestStatus EliminarDepartamento(string id)
        {
            string sql = ScriptsBaseDeDatos.Estad_Eliminar;
            using (var db = new SqlConnection(Sistemas_TurnosContext.ConnectionString))
            {
                var parametro = new DynamicParameters();
                parametro.Add("@Esta_Id", id);

                var result = db.Execute(
                    sql, parametro,
                    commandType: CommandType.StoredProcedure
                );

                string mensaje = (result == 1) ? "exito" : "error";

                return new RequestStatus { CodeStatus = result, MessageStatus = mensaje };

            };
        }

        public tbEstados Details(int? id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<tbEstados> find(string Esta_Id)
        {
            string sql = ScriptsBaseDeDatos.Estad_Obtener;

            List<tbEstados> result = new List<tbEstados>();

            using (var db = new SqlConnection(Sistemas_TurnosContext.ConnectionString))
            {
                var parameters = new { Esta_Id };
                result = db.Query<tbEstados>(sql, parameters, commandType: CommandType.StoredProcedure).ToList();
                return result;
            }
        }

        public tbEstados find(int? id)
        {
            throw new NotImplementedException();
        }

        public RequestStatus Insert(tbEstados item)
        {
            string sql = ScriptsBaseDeDatos.Estad_Insertar;

            using (var db = new SqlConnection(Sistemas_TurnosContext.ConnectionString))
            {
                var parameter = new DynamicParameters();
                parameter.Add("@Esta_Id", item.Esta_Id);
                parameter.Add("@Esta_Descripcion", item.Esta_Descripcion);
                parameter.Add("@Esta_Creacion", item.Esta_Creacion);
                parameter.Add("@Esta_FechaCreacion", item.Esta_FechaCreacion);

                var result = db.Execute(sql, parameter, commandType: CommandType.StoredProcedure);
                string mensaje = (result == 1) ? "exito" : "error";
                return new RequestStatus { CodeStatus = result, MessageStatus = mensaje };

                //var result = db.QueryFirst(sql, parameter, commandType: CommandType.Text);

                //return result;
            }
        }

        public IEnumerable<tbEstados> List()
        {
            string sql = ScriptsBaseDeDatos.Estad_Listar;

            List<tbEstados> result = new List<tbEstados>();

            using (var db = new SqlConnection(Sistemas_TurnosContext.ConnectionString))
            {
                result = db.Query<tbEstados>(sql, commandType: CommandType.Text).ToList();

                return result;
            }
            //throw new NotImplementedException();
        }

        public IEnumerable<tbEstados> List(string Esta_Id)
        {
            string sql = ScriptsBaseDeDatos.Estad_Obtener;

            List<tbEstados> result = new List<tbEstados>();

            using (var db = new SqlConnection(Sistemas_TurnosContext.ConnectionString))
            {
                var parameters = new { Esta_Id };
                result = db.Query<tbEstados>(sql, parameters, commandType: CommandType.StoredProcedure).ToList();
                return result;
            }
        }

        public IEnumerable<tbEstados> ObtenerEstado(string Esta_Descripcion)
        {
            string sql = ScriptsBaseDeDatos.Estad_ObtenerEstado;

            List<tbEstados> result = new List<tbEstados>();

            using (var db = new SqlConnection(Sistemas_TurnosContext.ConnectionString))
            {
                var parameters = new { Esta_Descripcion };
                result = db.Query<tbEstados>(sql, parameters, commandType: CommandType.StoredProcedure).ToList();
                return result;
            }
        }

        public RequestStatus Update(tbEstados item)
        {
            string sql = ScriptsBaseDeDatos.Estad_Actualizar;

            using (var db = new SqlConnection(Sistemas_TurnosContext.ConnectionString))
            {
                var parameter = new DynamicParameters();
                parameter.Add("@Esta_Id", item.Esta_Id);
                parameter.Add("@Esta_Descripcion", item.Esta_Descripcion);
                parameter.Add("@Esta_Modificacion", item.Esta_Modificacion);
                parameter.Add("@Esta_FechaModificacion", item.Esta_FechaModificacion);

                var result = db.Execute(sql, parameter, commandType: CommandType.StoredProcedure);
                string mensaje = (result == 1) ? "exito" : "error";
                return new RequestStatus { CodeStatus = result, MessageStatus = mensaje };

            }
        }
    }
}
