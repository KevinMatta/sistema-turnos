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
    public class UsuarioRepository : IRepository<tbUsuarios>
    {
        public RequestStatus Delete(tbUsuarios item)
        {
            throw new NotImplementedException();
        }

        public tbUsuarios Details(int? id)
        {
            throw new NotImplementedException();
        }

        public tbUsuarios find(int? id)
        {
            throw new NotImplementedException();
        }

        public RequestStatus Insert(tbUsuarios item)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<tbUsuarios> Login(string Usuario, string Contra)
        {
            string sql = ScriptsBaseDeDatos.Usua_Login;

            List<tbUsuarios> result = new List<tbUsuarios>();

            using (var db = new SqlConnection(Sistemas_TurnosContext.ConnectionString))
            {
                var parameters = new { @Usuario = Usuario , @Contra = Contra };
                result = db.Query<tbUsuarios>(sql, parameters, commandType: CommandType.StoredProcedure).ToList();
                return result;
            }
        }
        public IEnumerable<tbUsuarios> List()
        {
            throw new NotImplementedException();
        }

        public RequestStatus Update(tbUsuarios item)
        {
            throw new NotImplementedException();
        }
    }
}
