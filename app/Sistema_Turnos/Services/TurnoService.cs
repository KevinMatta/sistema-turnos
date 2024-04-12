using Sistema_Turnos.Models;
using Sistema_Turnos.WebAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sistema_Turnos.Services
{
    public class TurnoService
    {
        private readonly API _api;

        public TurnoService(API api)
        {
            _api = api;
        }

        public async Task<ServiceResult> TurnosList()
        {
            var result = new ServiceResult();
            try
            {
                var response = await _api.Get<IEnumerable<TurnoViewModel>, IEnumerable<TurnoViewModel>>(req =>
                {
                    req.Path = $"API/Turno/ListarTurnos";
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

        public async Task<ServiceResult> CrearTurno(TurnoViewModel item)
        {
            var result = new ServiceResult();
            try
            {
                var response = await _api.Post<TurnoViewModel, ServiceResult>(req =>
                {
                    req.Path = $"API/Turno/CreateTurnos";
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

        public async Task<ServiceResult> ObtenerTurno(int turn_Id)
        {
            var result = new ServiceResult();
            try
            {
                var response = await _api.Get<IEnumerable<TurnoViewModel>, TurnoViewModel>(req =>
                {
                    req.Path = $"API/Turno/FillTurnos/{turn_Id}";
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

        public async Task<ServiceResult> EditarTurno(TurnoViewModel item)
        {
            var result = new ServiceResult();
            try
            {
                var response = await _api.Put<TurnoViewModel, ServiceResult>(req =>
                {
                    req.Path = $"API/Turno/UpdateTurnos";
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

        public async Task<ServiceResult> EliminarTurno(int id, int modificacion, DateTime fecha)
        {
            var result = new ServiceResult();
            try
            {
                var response = await _api.Delete<TurnoViewModel, ServiceResult>(req =>
                {
                    req.Path = $"API/Turno/DeleteTurnos?id={id}&modificacion={modificacion}&fecha={fecha}";
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

        public async Task<ServiceResult> DetallesTurno(int turn_Id)
        {
            var result = new ServiceResult();
            try
            {
                var response = await _api.Get<IEnumerable<TurnoViewModel>, IEnumerable<TurnoViewModel>>(req =>
                {
                    req.Path = $"API/Turno/FillTurnos/{turn_Id}";
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
