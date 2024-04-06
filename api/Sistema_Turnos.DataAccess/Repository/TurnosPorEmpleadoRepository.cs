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
    public class TurnosPorEmpleadoRepository : IRepository<tbTurnosPorEmpleados>
    {
        public RequestStatus Delete(tbTurnosPorEmpleados item)
        {
            throw new NotImplementedException();
        }

        public tbTurnosPorEmpleados Details(int? id)
        {
            throw new NotImplementedException();
        }

        public tbTurnosPorEmpleados find(int? id)
        {
            throw new NotImplementedException();
        }

        public RequestStatus Insert(tbTurnosPorEmpleados item)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<tbTurnosPorEmpleados> List()
        {
            string sql = ScriptsBaseDeDatos.TuEm_Listar;

            List<tbTurnosPorEmpleados> result = new List<tbTurnosPorEmpleados>();

            using (var db = new SqlConnection(Sistemas_TurnosContext.ConnectionString))
            {
                result = db.Query<tbTurnosPorEmpleados>(sql, commandType: CommandType.Text).ToList();

                return result;
            }
        }

        public RequestStatus Update(tbTurnosPorEmpleados item)
        {
            throw new NotImplementedException();
        }
    }
}
