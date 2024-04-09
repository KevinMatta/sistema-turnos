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
    public class RolesRepository : IRepository<tbRoles>
    {
        public RequestStatus Delete(tbRoles item)
        {
            throw new NotImplementedException();
        }

        public RequestStatus EliminarRol(int Rol_Id)
        {
            string sql = ScriptsBaseDeDatos.Rol_Eliminar;
            using (var db = new SqlConnection(Sistemas_TurnosContext.ConnectionString))
            {
                var parametro = new DynamicParameters();
                parametro.Add("@Rol_Id", Rol_Id);

                var result = db.Execute(
                    sql, parametro,
                    commandType: CommandType.StoredProcedure
                );

                string mensaje = (result == 1) ? "exito" : "error";

                return new RequestStatus { CodeStatus = result, MessageStatus = mensaje };

            };
        }

        public RequestStatus EliminarPantallaPorRol(int PaRo_Id)
        {
            string sql = ScriptsBaseDeDatos.PanRo_Eliminar;
            using (var db = new SqlConnection(Sistemas_TurnosContext.ConnectionString))
            {
                var parametro = new DynamicParameters();
                parametro.Add("@PaRo_Id", PaRo_Id);

                var result = db.Execute(
                    sql, parametro,
                    commandType: CommandType.StoredProcedure
                );

                string mensaje = (result == 1) ? "exito" : "error";

                return new RequestStatus { CodeStatus = result, MessageStatus = mensaje };

            };
        }

        public tbRoles Details(int? id)
        {
            throw new NotImplementedException();
        }

        public tbRoles find(int? id)
        {
            throw new NotImplementedException();
        }

        public RequestStatus InsertPantallasRoles(tbPantallasPorRoles item)
        {
            string sql = ScriptsBaseDeDatos.PanRo_Insertar;

            using (var db = new SqlConnection(Sistemas_TurnosContext.ConnectionString))
            {
                var parameter = new DynamicParameters();
                parameter.Add("@Rol_Id", item.Rol_Id);
                parameter.Add("@Pant_Id", item.Pant_Id);
                parameter.Add("@PaRo_Creacion", item.PaRo_Creacion);
                parameter.Add("@PaRo_FechaCreacion", item.PaRo_FechaCreacion);

                var result = db.Execute(sql, parameter, commandType: CommandType.StoredProcedure);
                string mensaje = (result == 1) ? "exito" : "error";
                return new RequestStatus { CodeStatus = result, MessageStatus = mensaje };

                //var result = db.QueryFirst(sql, parameter, commandType: CommandType.Text);

                //return result;
            }
        }

        public RequestStatus Insert(tbRoles item)
        {
            string sql = ScriptsBaseDeDatos.Rol_Insertar;

            using (var db = new SqlConnection(Sistemas_TurnosContext.ConnectionString))
            {
                var parameter = new DynamicParameters();
                parameter.Add("@Rol_Descripcion", item.Rol_Descripcion);
                parameter.Add("@Rol_Creacion", item.Rol_Creacion);
                parameter.Add("@Rol_FechaCreacion", item.Rol_FechaCreacion);
                parameter.Add("@Rol_id", dbType: DbType.Int32, direction: ParameterDirection.Output); // Agrega el parámetro de salida

                db.Execute(sql, parameter, commandType: CommandType.StoredProcedure);

                int Rol_id = parameter.Get<int>("@Rol_id"); // Obtén el nuevo ID del parámetro de salida

                string mensaje = (Rol_id > 0) ? "exito" : "error";
                return new RequestStatus { CodeStatus = Rol_id, MessageStatus = mensaje };
            }
        }


        public IEnumerable<tbRoles> List()
        {
            string sql = ScriptsBaseDeDatos.Rol_Listar;

            List<tbRoles> result = new List<tbRoles>();

            using (var db = new SqlConnection(Sistemas_TurnosContext.ConnectionString))
            {
                result = db.Query<tbRoles>(sql, commandType: CommandType.Text).ToList();

                return result;
            }
        }

        public IEnumerable<tbRoles> ValidarUrl(int Pant_Id, int Rol_Id)
        {
            string sql = ScriptsBaseDeDatos.Validar_Url;

            List<tbRoles> result = new List<tbRoles>();

            using (var db = new SqlConnection(Sistemas_TurnosContext.ConnectionString))
            {
                var parameters = new { Pant_Id, Rol_Id };
                result = db.Query<tbRoles>(sql, parameters, commandType: CommandType.StoredProcedure).ToList();
                return result;
            }
        }

        public IEnumerable<tbRoles> findObtenerId(string Rol, int usuario_creacion, DateTime fecha_creacion)
        {
            string sql = ScriptsBaseDeDatos.Rol_ObtenerId;

            List<tbRoles> result = new List<tbRoles>();

            using (var db = new SqlConnection(Sistemas_TurnosContext.ConnectionString))
            {
                var parameters = new { Rol, usuario_creacion , fecha_creacion };
                result = db.Query<tbRoles>(sql, parameters, commandType: CommandType.StoredProcedure).ToList();
                return result;
            }
        }

        public IEnumerable<tbPantallasPorRoles> ObtenerRol(int Rol_Id)
        {
            string sql = ScriptsBaseDeDatos.Rol_Obtener;

            List<tbPantallasPorRoles> result = new List<tbPantallasPorRoles>();

            using (var db = new SqlConnection(Sistemas_TurnosContext.ConnectionString))
            {
                var parameters = new { Rol_Id = Rol_Id };
                result = db.Query<tbPantallasPorRoles>(sql, parameters, commandType: CommandType.StoredProcedure).ToList();
                return result;
            }
        }

        public IEnumerable<tbPantallasPorRoles> BuscarPantallasPorRol(int Rol_Id)
        {
            string sql = ScriptsBaseDeDatos.PanRo_Buscar;

            List<tbPantallasPorRoles> result = new List<tbPantallasPorRoles>();

            using (var db = new SqlConnection(Sistemas_TurnosContext.ConnectionString))
            {
                var parameters = new { Rol_Id  = Rol_Id };
                result = db.Query<tbPantallasPorRoles>(sql, parameters, commandType: CommandType.StoredProcedure).ToList();
                return result;
            }
        }
        public RequestStatus Update(tbRoles item)
        {
            string sql = ScriptsBaseDeDatos.Rol_Actualizar;

            using (var db = new SqlConnection(Sistemas_TurnosContext.ConnectionString))
            {
                var parameter = new DynamicParameters();
                parameter.Add("@Rol_Id", item.Rol_Descripcion);
                parameter.Add("@Rol_Descripcion", item.Rol_Descripcion);
                parameter.Add("@Rol_Modificacion", item.Rol_Modificacion);
                parameter.Add("@Rol_FechaModificacion", item.Rol_FechaModificacion);

                var result = db.Execute(sql, parameter, commandType: CommandType.StoredProcedure);

                string mensaje = (result > 0) ? "exito" : "error";
                return new RequestStatus { CodeStatus = result, MessageStatus = mensaje };
            }

            //throw new NotImplementedException();
        }
    }
}
