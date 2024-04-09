using Sistema_Turnos.DataAccess.Repository;
using Sistema_Turnos.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sistema_Turnos.BusinessLogic.Services
{
    public class GeneralService
    {
        private readonly DepartamentoRepository _departamentoRepository1;
        public GeneralService(DepartamentoRepository departamentoRepository)
        {
            _departamentoRepository1 = departamentoRepository;
        }

        #region Estado 

        public ServiceResult ListEstado()
        {
            var result = new ServiceResult();
            try
            {
                var lost = _departamentoRepository1.List();
                return result.Ok(lost);
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }
        public ServiceResult InsertarEstado(tbEstados item)
        {
            var result = new ServiceResult();
            try
            {
                var lost = _departamentoRepository1.Insert(item);
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

        public ServiceResult EliminarEstado(string id)
        {
            var result = new ServiceResult();
            try
            {
                var lost = _departamentoRepository1.EliminarDepartamento(id);
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

        public ServiceResult ActualizarEstado(tbEstados item)
        {
            var result = new ServiceResult();
            try
            {
                var lost = _departamentoRepository1.Update(item);
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

        public ServiceResult ObtenerEstado(string Esta_Id)
        {
            var result = new ServiceResult();
            try
            {
                var lost = _departamentoRepository1.find(Esta_Id);
                return result.Ok(lost);
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }

        public ServiceResult ListDepto(string id)
        {
            var result = new ServiceResult();
            try
            {
                var list = _departamentoRepository1.List(id);

                return result.Ok(list);
            }
            catch (Exception ex)
            {
                return result.Error(ex);
            }
        }

        public ServiceResult ObtenerEsta(string Esta_Descripcion)
        {
            var result = new ServiceResult();
            try
            {
                var list = _departamentoRepository1.ObtenerEstado(Esta_Descripcion);

                return result.Ok(list);
            }
            catch (Exception ex)
            {
                return result.Error(ex);
            }
        }

        #endregion
    }
}
