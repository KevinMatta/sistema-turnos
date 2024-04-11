using Sistema_Turnos.Models;
using Sistema_Turnos.WebAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sistema_Turnos.Services
{
    public class EstadoCivilService
    {
        private readonly API _api;
        public EstadoCivilService(API api)
        {
            _api = api;
        }

        public async Task<ServiceResult> ObtenerEstadoCivilList()
        {
            var result = new ServiceResult();
            try
            {
                var response = await _api.Get<IEnumerable<EstadoCivilViewModel>, IEnumerable<EstadoCivilViewModel>>(req =>
                {
                    req.Path = $"API/EstadoCivil/ListadoEstadosCiviles";
                });
                if (!response.Success)
                {
                    return result.FromApi(response);
                }
                else
                {
                    return result.Ok(response.Data);
                }
            }
            catch (Exception ex)
            {
                return result.Error(Helpers.GetMessage(ex));
                throw;
            }
        }

        public async Task<ServiceResult> CrearEstadoCivil(EstadoCivilViewModel item)
        {
            var result = new ServiceResult();
            try
            {
                var response = await _api.Post<EstadoCivilViewModel, ServiceResult>(req =>
                {
                    req.Path = $"API/EstadoCivil/CreateEstadosCiviles";
                    req.Content = item;
                });
                if (!response.Success)
                {
                    return result.FromApi(response);
                }
                else
                {
                    return result.Ok(response.Data);
                }
            }
            catch (Exception ex)
            {
                return result.Error(Helpers.GetMessage(ex));
                throw;
            }
        }

        public async Task<ServiceResult> ObtenerEstadoCivil(int EsCi_Id)
        {
            var result = new ServiceResult();
            try
            {
                var response = await _api.Get<IEnumerable<EstadoCivilViewModel>, EstadoCivilViewModel>(req =>
                {
                    req.Path = $"API/EstadoCivil/FillEstadosCiviles/{EsCi_Id}";
                });
                if (!response.Success)
                {
                    return result.FromApi(response);
                }
                else
                {
                    return result.Ok(response.Data);
                }
            }
            catch (Exception ex)
            {
                return result.Error(Helpers.GetMessage(ex));
                throw;
            }
        }

        public async Task<ServiceResult> EditarEstadoCivil(EstadoCivilViewModel item)
        {
            var result = new ServiceResult();
            try
            {
                var response = await _api.Put<EstadoCivilViewModel, ServiceResult>(req =>
                {
                    req.Path = $"API/EstadoCivil/UpdateEstadosCiviles";
                    req.Content = item;
                });
                if (!response.Success)
                {
                    return result.FromApi(response);
                }
                else
                {
                    return result.Ok(response.Data);
                }
            }
            catch (Exception ex)
            {
                return result.Error(Helpers.GetMessage(ex));
                throw;
            }
        }

        public async Task<ServiceResult> EliminarEstadoCivil(int EsCi_Id, int EsCi_Modificacion, DateTime EsCi_FechaModificacion)
        {
            var result = new ServiceResult();
            try
            {
                var response = await _api.Delete<EstadoCivilViewModel, ServiceResult>(req =>
                {
                    req.Path = $"API/EstadoCivil/DeleteEstadosCiviles?EsCi_Id={EsCi_Id}&EsCi_Modificacion={EsCi_Modificacion}&EsCi_FechaModificacion={EsCi_FechaModificacion}";
                });
                if (!response.Success)
                {
                    return result.FromApi(response);
                }
                else
                {
                    return result.Ok(response.Data);
                }
            }
            catch (Exception ex)
            {
                return result.Error(Helpers.GetMessage(ex));
                throw;
            }
        }

        public async Task<ServiceResult> DetallesEstadoCivil(int EsCi_Id)
        {
            var result = new ServiceResult();
            try
            {
                var response = await _api.Get<IEnumerable<EstadoCivilViewModel>, IEnumerable<EstadoCivilViewModel>>(req =>
                {
                    req.Path = $"API/EstadoCivil/FillEstadosCiviles/{EsCi_Id}";
                });
                if (!response.Success)
                {
                    return result.FromApi(response);
                }
                else
                {
                    // Aquí deberías devolver directamente el objeto DepartamentoViewModel
                    return result.Ok(response.Data);
                }
            }
            catch (Exception ex)
            {
                return result.Error(Helpers.GetMessage(ex));
                throw;
            }
        }
    }
}
