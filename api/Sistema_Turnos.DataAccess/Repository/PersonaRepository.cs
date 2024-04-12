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
    public class PersonaRepository : IRepository<tbPersonas>
    {
        public RequestStatus Delete(tbPersonas item)
        {
            throw new NotImplementedException();
        }

        public RequestStatus EliminarPersona(int id, int usuario, DateTime fecha)
        {
            string sql = ScriptsBaseDeDatos.Person_Eliminar;
            using (var db = new SqlConnection(Sistemas_TurnosContext.ConnectionString))
            {
                var parametro = new DynamicParameters();
                parametro.Add("@Pers_Identidad", id);
                parametro.Add("@Pers_Modificacion", usuario);
                parametro.Add("@Pers_FechaModificacion", fecha);

                var result = db.Execute(
                    sql, parametro,
                    commandType: CommandType.StoredProcedure
                );

                string mensaje = (result == 1) ? "exito" : "error";

                return new RequestStatus { CodeStatus = result, MessageStatus = mensaje };

            };
        }

        public tbPersonas Details(int? id)
        {
            throw new NotImplementedException();
        }

        public tbPersonas find(int? id)
        {
            throw new NotImplementedException();
        }

        public RequestStatus Insert(tbPersonas item)
        {
            string sql = ScriptsBaseDeDatos.Person_Insertar;

            using (var db = new SqlConnection(Sistemas_TurnosContext.ConnectionString))
            {
                var parameter = new DynamicParameters();
                parameter.Add("@Pers_Identidad", item.Pers_Identidad);
                parameter.Add("@Pers_PrimerNombre", item.Pers_PrimerNombre);
                parameter.Add("@Pers_SegundoNombre", item.Pers_SegundoNombre);
                parameter.Add("@Pers_PrimerApellido", item.Pers_PrimerApellido);
                parameter.Add("@Pers_SegundoApellido", item.Pers_SegundoApellido);
                parameter.Add("@EsCi_Id", item.EsCi_Id);
                parameter.Add("@Pers_Sexo", item.Pers_Sexo);
                parameter.Add("@Pers_Creacion", item.Pers_Creacion);
                parameter.Add("@Pers_FechaCreacion", item.Pers_FechaCreacion);

                var result = db.Execute(sql, parameter, commandType: CommandType.StoredProcedure);
                string mensaje = (result == 1) ? "exito" : "error";
                return new RequestStatus { CodeStatus = result, MessageStatus = mensaje };

            }
        }

        public IEnumerable<tbPersonas> List()
        {
            string sql = ScriptsBaseDeDatos.Person_Listar;

            List<tbPersonas> result = new List<tbPersonas>();

            using (var db = new SqlConnection(Sistemas_TurnosContext.ConnectionString))
            {
                result = db.Query<tbPersonas>(sql, commandType: CommandType.Text).ToList();

                return result;
            }
        }

        public IEnumerable<tbPersonas> List(string Pers_Identidad)
        {
            string sql = ScriptsBaseDeDatos.Person_Obtener;

            List<tbPersonas> result = new List<tbPersonas>();

            using (var db = new SqlConnection(Sistemas_TurnosContext.ConnectionString))
            {
                var parameters = new { Pers_Identidad };
                result = db.Query<tbPersonas>(sql, parameters, commandType: CommandType.StoredProcedure).ToList();
                return result;
            }
        }

        public RequestStatus Update(tbPersonas item)
        {
            string sql = ScriptsBaseDeDatos.Person_Actualizar;

            using (var db = new SqlConnection(Sistemas_TurnosContext.ConnectionString))
            {
                var parameter = new DynamicParameters();
                parameter.Add("@Pers_Identidad", item.Pers_Identidad);
                parameter.Add("@Pers_PrimerNombre", item.Pers_PrimerNombre);
                parameter.Add("@Pers_SegundoNombre", item.Pers_SegundoNombre);
                parameter.Add("@Pers_PrimerApellido", item.Pers_PrimerApellido);
                parameter.Add("@Pers_SegundoApellido", item.Pers_SegundoApellido);
                parameter.Add("@EsCi_Id", item.EsCi_Id);
                parameter.Add("@Pers_Sexo", item.Pers_Sexo);
                parameter.Add("@Pers_Modificacion", item.Pers_Modificacion);
                parameter.Add("@Pers_FechaModificacion", item.Pers_FechaModificacion);

                var result = db.Execute(sql, parameter, commandType: CommandType.StoredProcedure);
                string mensaje = (result == 1) ? "exito" : "error";
                return new RequestStatus { CodeStatus = result, MessageStatus = mensaje };

            }
        }
    }
}
