using Sistema_Turnos.Models;
using Sistema_Turnos.WebAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sistema_Turnos.Services
{
    public class CargoService
    {
        private readonly API _api;
        public CargoService(API api)
        {
            _api = api;
        }

        public async Task<ServiceResult> ObtenerCargoList()
        {
            var result = new ServiceResult();
            try
            {
                var response = await _api.Get<IEnumerable<CargoViewModel>, IEnumerable<CargoViewModel>>(req =>
                {
                    req.Path = $"API/Cargo/ListadoCargos";
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

        public async Task<ServiceResult> CrearCargo(CargoViewModel item)
        {
            var result = new ServiceResult();
            try
            {
                var response = await _api.Post<CargoViewModel, ServiceResult>(req =>
                {
                    req.Path = $"API/Cargo/CreateCargos";
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

        public async Task<ServiceResult> ObtenerCargo(int Carg_Id)
        {
            var result = new ServiceResult();
            try
            {
                var response = await _api.Get<IEnumerable<CargoViewModel>, CargoViewModel>(req =>
                {
                    req.Path = $"API/Cargo/FillCargos/{Carg_Id}";
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

        public async Task<ServiceResult> EditarCargo(CargoViewModel item)
        {
            var result = new ServiceResult();
            try
            {
                var response = await _api.Put<CargoViewModel, ServiceResult>(req =>
                {
                    req.Path = $"API/Cargo/UpdateCargos";
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

        public async Task<ServiceResult> EliminarCargo(int Carg_Id, int Carg_Modificacion, DateTime Carg_FechaModificacion)
        {
            var result = new ServiceResult();
            try
            {
                var response = await _api.Delete<CargoViewModel, ServiceResult>(req =>
                {
                    req.Path = $"API/Cargo/DeleteCargos?Carg_Id={Carg_Id}&Carg_Modificacion={Carg_Modificacion}&Carg_FechaModificacion={Carg_FechaModificacion}";
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

        public async Task<ServiceResult> DetallesCargo(int Carg_Id)
        {
            var result = new ServiceResult();
            try
            {
                var response = await _api.Get<IEnumerable<CargoViewModel>, IEnumerable<CargoViewModel>>(req =>
                {
                    req.Path = $"API/Cargo/FillCargos/{Carg_Id}";
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
