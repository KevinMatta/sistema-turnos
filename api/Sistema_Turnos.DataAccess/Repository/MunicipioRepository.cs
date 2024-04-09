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
    public class MunicipioRepository : IRepository<tbCiudades>
    {
        public RequestStatus Delete(tbCiudades item)
        {
            throw new NotImplementedException();
        }

        public RequestStatus EliminarMunicipio(string id)
        {
            string sql = ScriptsBaseDeDatos.Munic_Eliminar;
            using (var db = new SqlConnection(Sistemas_TurnosContext.ConnectionString))
            {
                var parametro = new DynamicParameters();
                parametro.Add("@Ciud_Id", id);

                var result = db.Execute(
                    sql, parametro,
                    commandType: CommandType.StoredProcedure
                );

                string mensaje = (result == 1) ? "exito" : "error";

                return new RequestStatus { CodeStatus = result, MessageStatus = mensaje };

            };
        }

        public tbCiudades Details(int? id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<tbCiudades> find(string Ciud_Id)
        {
            string sql = ScriptsBaseDeDatos.Munic_Obtener;

            List<tbCiudades> result = new List<tbCiudades>();

            using (var db = new SqlConnection(Sistemas_TurnosContext.ConnectionString))
            {
                var parameters = new { Ciud_Id };
                result = db.Query<tbCiudades>(sql, parameters, commandType: CommandType.StoredProcedure).ToList();
                return result;
            }
        }

        public tbCiudades find(int? id)
        {
            throw new NotImplementedException();
        }

        public RequestStatus Insert(tbCiudades item)
        {
            string sql = ScriptsBaseDeDatos.Munic_Insertar;

            using (var db = new SqlConnection(Sistemas_TurnosContext.ConnectionString))
            {
                var parameter = new DynamicParameters();
                parameter.Add("@Ciud_Id", item.Ciud_Id);
                parameter.Add("@Esta_Id", item.Esta_Id);
                parameter.Add("@Ciud_Descripcion", item.Ciud_Descripcion);
                parameter.Add("@Ciud_Creacion", item.Ciud_Creacion);
                parameter.Add("@Ciud_FechaCreacion", item.Ciud_FechaCreacion);

                var result = db.Execute(sql, parameter, commandType: CommandType.StoredProcedure);
                string mensaje = (result == 1) ? "exito" : "error";
                return new RequestStatus { CodeStatus = result, MessageStatus = mensaje };

                //var result = db.QueryFirst(sql, parameter, commandType: CommandType.Text);

                //return result;
            }
        }

        public IEnumerable<tbCiudades> List()
        {
            string sql = ScriptsBaseDeDatos.Munic_Listar;

            List<tbCiudades> result = new List<tbCiudades>();

            using (var db = new SqlConnection(Sistemas_TurnosContext.ConnectionString))
            {
                result = db.Query<tbCiudades>(sql, commandType: CommandType.Text).ToList();

                return result;
            }
        }

        public IEnumerable<tbCiudades> List(string Ciud_Id)
        {
            string sql = ScriptsBaseDeDatos.Munic_Obtener;

            List<tbCiudades> result = new List<tbCiudades>();

            using (var db = new SqlConnection(Sistemas_TurnosContext.ConnectionString))
            {
                var parameters = new { Ciud_Id };
                result = db.Query<tbCiudades>(sql, parameters, commandType: CommandType.StoredProcedure).ToList();
                return result;
            }
        }

        public RequestStatus Update(tbCiudades item)
        {
            string sql = ScriptsBaseDeDatos.Munic_Actualizar;

            using (var db = new SqlConnection(Sistemas_TurnosContext.ConnectionString))
            {
                var parameter = new DynamicParameters();
                parameter.Add("@Ciud_Id", item.Ciud_Id);
                parameter.Add("@Esta_Id", item.Esta_Id);
                parameter.Add("@Ciud_Descripcion", item.Ciud_Descripcion);
                parameter.Add("@Ciud_Creacion", item.Ciud_Creacion);
                parameter.Add("@Ciud_FechaCreacion", item.Ciud_FechaCreacion);

                var result = db.Execute(sql, parameter, commandType: CommandType.StoredProcedure);
                string mensaje = (result == 1) ? "exito" : "error";
                return new RequestStatus { CodeStatus = result, MessageStatus = mensaje };

            }
        }
    }
}
