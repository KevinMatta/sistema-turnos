using Sistema_Turnos.Models;
using Sistema_Turnos.WebAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sistema_Turnos.Services
{
    public class TurnosPorEmpleadoService
    {
        private readonly API _api;

        public TurnosPorEmpleadoService(API api)
        {
            _api = api;
        }

        public async Task<ServiceResult> TurnosPorEmpleadoList()
        {
            var result = new ServiceResult();
            try
            {
                var response = await _api.Get<IEnumerable<TurnosPorEmpleadoViewModel>, IEnumerable<TurnosPorEmpleadoViewModel>>(req =>
                {
                    req.Path = $"API/TurnosPorEmpleado/ListTurnosEmpleados";
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

        public async Task<ServiceResult> CrearTurnoEmpleado(TurnosPorEmpleadoViewModel item)
        {
            var result = new ServiceResult();
            try
            {
                var response = await _api.Post<TurnosPorEmpleadoViewModel, ServiceResult>(req =>
                {
                    req.Path = $"/API/TurnosPorEmpleado/Crear";
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

        public async Task<ServiceResult> BuscarTurnoEmpleado(int item)
        {
            var result = new ServiceResult();
            try
            {
                var response = await _api.Get<TurnosPorEmpleadoViewModel, ServiceResult>(req =>
                {
                    req.Path = $"/API/TurnosPorEmpleado/Buscar/{item}";
                    //req.Content = item;
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

        public async Task<ServiceResult> EditarTurnoEmpleado(TurnosPorEmpleadoViewModel item)
        {
            var result = new ServiceResult();
            try
            {
                var response = await _api.Post<TurnosPorEmpleadoViewModel, ServiceResult>(req =>
                {
                    req.Path = $"/API/TurnosPorEmpleado/Buscar";
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
    }
}
