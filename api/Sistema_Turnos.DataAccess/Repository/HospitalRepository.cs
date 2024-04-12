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
    public class HospitalRepository : IRepository<tbHospitales>
    {
        public RequestStatus Delete(tbHospitales item)
        {
            throw new NotImplementedException();
        }

        public RequestStatus EliminarHospital(int id, int usuario, DateTime fecha)
        {
            string sql = ScriptsBaseDeDatos.Hospi_Eliminar;
            using (var db = new SqlConnection(Sistemas_TurnosContext.ConnectionString))
            {
                var parametro = new DynamicParameters();
                parametro.Add("@Hosp_Id", id);
                parametro.Add("@Hosp_Modificacion", usuario);
                parametro.Add("@Hosp_FechaModificacion", fecha);

                var result = db.Execute(
                    sql, parametro,
                    commandType: CommandType.StoredProcedure
                );

                string mensaje = (result == 1) ? "exito" : "error";

                return new RequestStatus { CodeStatus = result, MessageStatus = mensaje };

            };
        }

        public tbHospitales Details(int? id)
        {
            throw new NotImplementedException();
        }

        public tbHospitales find(int? id)
        {
            throw new NotImplementedException();
        }

        public RequestStatus Insert(tbHospitales item)
        {
            string sql = ScriptsBaseDeDatos.Hospi_Insertar;

            using (var db = new SqlConnection(Sistemas_TurnosContext.ConnectionString))
            {
                var parameter = new DynamicParameters();
                parameter.Add("@Hosp_Descripcion", item.Hosp_Descripcion);
                parameter.Add("@Hosp_Direccion", item.Hosp_Direccion);
                parameter.Add("@Ciud_Id", item.Ciud_Id);
                parameter.Add("@Hosp_Creacion", item.Hosp_Creacion);
                parameter.Add("@Hosp_FechaCreacion", item.Hosp_FechaCreacion);

                var result = db.Execute(sql, parameter, commandType: CommandType.StoredProcedure);
                string mensaje = (result == 1) ? "exito" : "error";
                return new RequestStatus { CodeStatus = result, MessageStatus = mensaje };

                //var result = db.QueryFirst(sql, parameter, commandType: CommandType.Text);

                //return result;
            }
        }

        public IEnumerable<tbHospitales> List()
        {
            string sql = ScriptsBaseDeDatos.Hospi_Listar;

            List<tbHospitales> result = new List<tbHospitales>();

            using (var db = new SqlConnection(Sistemas_TurnosContext.ConnectionString))
            {
                result = db.Query<tbHospitales>(sql, commandType: CommandType.Text).ToList();

                return result;
            }
        }

        public IEnumerable<tbHospitales> List(int Hosp_Id)
        {
            string sql = ScriptsBaseDeDatos.Hospi_Obtener;

            List<tbHospitales> result = new List<tbHospitales>();

            using (var db = new SqlConnection(Sistemas_TurnosContext.ConnectionString))
            {
                var parameters = new { Hosp_Id };
                result = db.Query<tbHospitales>(sql, parameters, commandType: CommandType.StoredProcedure).ToList();
                return result;
            }
        }

        public RequestStatus Update(tbHospitales item)
        {
            string sql = ScriptsBaseDeDatos.Hospi_Actualizar;

            using (var db = new SqlConnection(Sistemas_TurnosContext.ConnectionString))
            {
                var parameter = new DynamicParameters();
                parameter.Add("@Hosp_Id", item.Hosp_Id);
                parameter.Add("@Hosp_Descripcion", item.Hosp_Descripcion);
                parameter.Add("@Hosp_Direccion", item.Hosp_Direccion);
                parameter.Add("@Ciud_Id", item.Ciud_Id);
                parameter.Add("@Hosp_Modificacion", item.Hosp_Modificacion);
                parameter.Add("@Hosp_FechaModificacion", item.Hosp_FechaModificacion);

                var result = db.Execute(sql, parameter, commandType: CommandType.StoredProcedure);
                string mensaje = (result == 1) ? "exito" : "error";
                return new RequestStatus { CodeStatus = result, MessageStatus = mensaje };

            }
        }
    }
}
