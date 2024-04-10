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
    public class EstadoCivilRepository : IRepository<tbEstadosCiviles>
    {
        public RequestStatus Delete(tbEstadosCiviles item)
        {
            throw new NotImplementedException();
        }

        public RequestStatus EliminarEstadosCiviles(int id, int usuario, DateTime fecha)
        {
            string sql = ScriptsBaseDeDatos.Estci_Eliminar;
            using (var db = new SqlConnection(Sistemas_TurnosContext.ConnectionString))
            {
                var parametro = new DynamicParameters();
                parametro.Add("@EsCi_Id", id);
                parametro.Add("@EsCi_Modificacion", usuario);
                parametro.Add("@EsCi_FechaModificacion", fecha);

                var result = db.Execute(
                    sql, parametro,
                    commandType: CommandType.StoredProcedure
                );

                string mensaje = (result == 1) ? "exito" : "error";

                return new RequestStatus { CodeStatus = result, MessageStatus = mensaje };

            };
        }

        public tbEstadosCiviles Details(int? id)
        {
            throw new NotImplementedException();
        }

        public tbEstadosCiviles find(int? id)
        {
            throw new NotImplementedException();
        }

        public RequestStatus Insert(tbEstadosCiviles item)
        {
            string sql = ScriptsBaseDeDatos.Estci_Insertar;

            using (var db = new SqlConnection(Sistemas_TurnosContext.ConnectionString))
            {
                var parameter = new DynamicParameters();
                parameter.Add("@EsCi_Descripcion", item.EsCi_Descripcion);
                parameter.Add("@EsCi_Creacion", item.EsCi_Creacion);
                parameter.Add("@EsCi_FechaCreacion", item.EsCi_FechaCreacion);

                var result = db.Execute(sql, parameter, commandType: CommandType.StoredProcedure);
                string mensaje = (result == 1) ? "exito" : "error";
                return new RequestStatus { CodeStatus = result, MessageStatus = mensaje };

                //var result = db.QueryFirst(sql, parameter, commandType: CommandType.Text);

                //return result;
            }
        }

        public IEnumerable<tbEstadosCiviles> List()
        {
            string sql = ScriptsBaseDeDatos.Estci_Listar;

            List<tbEstadosCiviles> result = new List<tbEstadosCiviles>();

            using (var db = new SqlConnection(Sistemas_TurnosContext.ConnectionString))
            {
                result = db.Query<tbEstadosCiviles>(sql, commandType: CommandType.Text).ToList();

                return result;
            }
        }

        public IEnumerable<tbEstadosCiviles> List(int EsCi_Id)
        {
            string sql = ScriptsBaseDeDatos.Estci_Obtener;

            List<tbEstadosCiviles> result = new List<tbEstadosCiviles>();

            using (var db = new SqlConnection(Sistemas_TurnosContext.ConnectionString))
            {
                var parameters = new { EsCi_Id };
                result = db.Query<tbEstadosCiviles>(sql, parameters, commandType: CommandType.StoredProcedure).ToList();
                return result;
            }
        }

        public RequestStatus Update(tbEstadosCiviles item)
        {
            string sql = ScriptsBaseDeDatos.Estci_Actualizar;

            using (var db = new SqlConnection(Sistemas_TurnosContext.ConnectionString))
            {
                var parameter = new DynamicParameters();
                parameter.Add("@EsCi_Id", item.EsCi_Id);
                parameter.Add("@EsCi_Descripcion", item.EsCi_Descripcion);
                parameter.Add("@EsCi_Modificacion", item.EsCi_Modificacion);
                parameter.Add("@EsCi_FechaModificacion", item.EsCi_FechaModificacion);

                var result = db.Execute(sql, parameter, commandType: CommandType.StoredProcedure);
                string mensaje = (result == 1) ? "exito" : "error";
                return new RequestStatus { CodeStatus = result, MessageStatus = mensaje };

            }
        }
    }
}
