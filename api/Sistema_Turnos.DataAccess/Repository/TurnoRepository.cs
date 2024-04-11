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
            throw new NotImplementedException();
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

        public RequestStatus Update(tbTurnos item)
        {
            throw new NotImplementedException();
        }
    }
}
