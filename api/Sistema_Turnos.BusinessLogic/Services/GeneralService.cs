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
        private readonly MunicipioRepository _municipioRepository;
        private readonly CargoRepository _cargoRepository;
        private readonly EstadoCivilRepository _estadoCivilRepository;
        private readonly PersonaRepository _personaRepository;
        public GeneralService(DepartamentoRepository departamentoRepository, MunicipioRepository municipioRepository, CargoRepository cargoRepository, EstadoCivilRepository estadoCivilRepository, PersonaRepository personaRepository)
        {
            _departamentoRepository1 = departamentoRepository;
            _municipioRepository = municipioRepository;
            _cargoRepository = cargoRepository;
            _estadoCivilRepository = estadoCivilRepository;
            _personaRepository = personaRepository;
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

        #region Municipio
        public ServiceResult ListMunicipio()
        {
            var result = new ServiceResult();
            try
            {
                var lost = _municipioRepository.List();
                return result.Ok(lost);
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }

        public ServiceResult InsertarMunicipio(tbCiudades item)
        {
            var result = new ServiceResult();
            try
            {
                var lost = _municipioRepository.Insert(item);
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

        public ServiceResult EliminarMunicipio(string id)
        {
            var result = new ServiceResult();
            try
            {
                var lost = _municipioRepository.EliminarMunicipio(id);
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

        public ServiceResult ActualizarMunicipio(tbCiudades item)
        {
            var result = new ServiceResult();
            try
            {
                var lost = _municipioRepository.Update(item);
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

        public ServiceResult ListMunic(string id)
        {
            var result = new ServiceResult();
            try
            {
                var list = _municipioRepository.List(id);

                return result.Ok(list);
            }
            catch (Exception ex)
            {
                return result.Error(ex);
            }
        }

        #endregion

        #region Cargos

        public ServiceResult ListCargo()
        {
            var result = new ServiceResult();
            try
            {
                var lost = _cargoRepository.List();
                return result.Ok(lost);
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }

        public ServiceResult InsertarCargo(tbCargos item)
        {
            var result = new ServiceResult();
            try
            {
                var lost = _cargoRepository.Insert(item);
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

        public ServiceResult EliminarCargo(int id, int usuario, DateTime fecha)
        {
            var result = new ServiceResult();
            try
            {
                var lost = _cargoRepository.EliminarCargo(id, usuario, fecha);
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

        public ServiceResult ActualizarCargo(tbCargos item)
        {
            var result = new ServiceResult();
            try
            {
                var lost = _cargoRepository.Update(item);
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

        public ServiceResult ListCar(int id)
        {
            var result = new ServiceResult();
            try
            {
                var list = _cargoRepository.List(id);

                return result.Ok(list);
            }
            catch (Exception ex)
            {
                return result.Error(ex);
            }
        }

        #endregion

        #region EstadosCiviles

        public ServiceResult ListEstadosCiviles()
        {
            var result = new ServiceResult();
            try
            {
                var lost = _estadoCivilRepository.List();
                return result.Ok(lost);
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }

        public ServiceResult InsertarEstadosCiviles(tbEstadosCiviles item)
        {
            var result = new ServiceResult();
            try
            {
                var lost = _estadoCivilRepository.Insert(item);
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

        public ServiceResult EliminarEstadosCiviles(int id, int usuario, DateTime fecha)
        {
            var result = new ServiceResult();
            try
            {
                var lost = _estadoCivilRepository.EliminarEstadosCiviles(id, usuario, fecha);
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

        public ServiceResult ActualizarEstadosCiviles(tbEstadosCiviles item)
        {
            var result = new ServiceResult();
            try
            {
                var lost = _estadoCivilRepository.Update(item);
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

        public ServiceResult ListEstadosCiv(int id)
        {
            var result = new ServiceResult();
            try
            {
                var list = _estadoCivilRepository.List(id);

                return result.Ok(list);
            }
            catch (Exception ex)
            {
                return result.Error(ex);
            }
        }

        #endregion

        #region Personas
        public ServiceResult ListPersonas()
        {
            var result = new ServiceResult();
            try
            {
                var lost = _personaRepository.List();
                return result.Ok(lost);
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }

        public ServiceResult InsertarPersonas(tbPersonas item)
        {
            var result = new ServiceResult();
            try
            {
                var lost = _personaRepository.Insert(item);
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

        public ServiceResult EliminarPersonas(string id, int usuario, DateTime fecha)
        {
            var result = new ServiceResult();
            try
            {
                var lost = _personaRepository.EliminarPersona(id, usuario, fecha);
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

        public ServiceResult ActualizarPersonas(tbPersonas item)
        {
            var result = new ServiceResult();
            try
            {
                var lost = _personaRepository.Update(item);
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

        public ServiceResult ListPerson(string id)
        {
            var result = new ServiceResult();
            try
            {
                var list = _personaRepository.List(id);

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
