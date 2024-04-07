using Sistema_Turnos.DataAccess.Repository;
using Sistema_Turnos.Entities.Entities;
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

        public ServiceResult InsertarTurnoEmpleado(tbTurnosPorEmpleados item)
        {
            var result = new ServiceResult();
            try
            {
                var list = _turnosPorEmpleadoRepository.Insert(item);
                if (list.CodeStatus > 0)
                {
                    return result.Ok(list);
                }
                else
                {
                    return result.Error(list);
                }
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }

        public ServiceResult ActualizarTurnoEmpleado(tbTurnosPorEmpleados item)
        {
            var result = new ServiceResult();
            try
            {
                var list = _turnosPorEmpleadoRepository.Update(item);
                if (list.CodeStatus > 0)
                {
                    return result.Ok(list);
                }
                else
                {
                    return result.Error(list);
                }
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }

        public ServiceResult EliminarTurnoEmpleado(int id)
        {
            var result = new ServiceResult();
            try
            {
                var lost = _turnosPorEmpleadoRepository.Delete(id);
                if (lost.CodeStatus > 0)
                {
                    return result.Ok(lost);
                }
                else
                {
                    return result.Error(lost);
                }
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }

        public ServiceResult BuscarTurnoEmpleado(int id)
        {
            var result = new ServiceResult();
            try
            {
                var list = _turnosPorEmpleadoRepository.find(id);
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
