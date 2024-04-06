using Sistema_Turnos.DataAccess.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_Turnos.BusinessLogic.Services
{
    public class TurnoService
    {
        private readonly TurnosPorEmpleadoRepository _turnosPorEmpleadoRepository;
        public TurnoService(TurnosPorEmpleadoRepository turnosPorEmpleadoRepository)
        {
            _turnosPorEmpleadoRepository = turnosPorEmpleadoRepository;
        }

        #region TurnosPorEmpleado
        public ServiceResult ListTurnoEmpleado()
        {
            var result = new ServiceResult();
            try
            {
                var list = _turnosPorEmpleadoRepository.List();
                return result.Ok(list);
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }
        #endregion
    }
}
