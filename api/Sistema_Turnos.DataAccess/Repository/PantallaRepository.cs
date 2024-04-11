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
    public class PantallaRepository : IRepository<tbPantallas>
    {
        public RequestStatus Delete(tbPantallas item)
        {
            throw new NotImplementedException();
        }

        public tbPantallas Details(int? id)
        {
            throw new NotImplementedException();
        }

        public tbPantallas find(int? id)
        {
            throw new NotImplementedException();
        }

        public RequestStatus Insert(tbPantallas item)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<tbPantallas> List()
        {
            string sql = ScriptsBaseDeDatos.Panta_Listar;

            List<tbPantallas> result = new List<tbPantallas>();

            using (var db = new SqlConnection(Sistemas_TurnosContext.ConnectionString))
            {
                result = db.Query<tbPantallas>(sql, commandType: CommandType.Text).ToList();

                return result;
            }
            //throw new NotImplementedException();
        }

        public RequestStatus Update(tbPantallas item)
        {
            throw new NotImplementedException();
        }
    }
}
