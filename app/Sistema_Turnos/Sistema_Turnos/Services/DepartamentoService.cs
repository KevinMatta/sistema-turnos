using Sistema_Turnos.Models;
using Sistema_Turnos.WebAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sistema_Turnos.Services
{
    public class DepartamentoService
    {
        private readonly API _api;

        public DepartamentoService(API api)
        {
            _api = api;
        }
        public async Task<ServiceResult> ObtenerDepartamentoList()
        {
            var result = new ServiceResult();
            try
            {
                var response = await _api.Get<IEnumerable<DepartamentoViewModel>, IEnumerable<DepartamentoViewModel>>(req =>
                {
                    req.Path = $"API/Departamento/ListadoDepartamentos";
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

        public async Task<ServiceResult> CrearDepartamento(DepartamentoViewModel item)
        {
            var result = new ServiceResult();
            try
            {
                var response = await _api.Post<DepartamentoViewModel, ServiceResult>(req =>
                {
                    req.Path = $"API/Departamento/CreateDepartamentos";
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

        public async Task<ServiceResult> ObtenerDepartamento(string Esta_Id)
        {
            var result = new ServiceResult();
            try
            {
                var response = await _api.Get<IEnumerable<DepartamentoViewModel>, DepartamentoViewModel>(req =>
                {
                    req.Path = $"API/Departamento/FillDepartamentos?Esta_Id={Esta_Id}";
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

        public async Task<ServiceResult> EditarDepartamento(DepartamentoViewModel item)
        {
            var result = new ServiceResult();
            try
            {
                var response = await _api.Put<DepartamentoViewModel, ServiceResult>(req =>
                {
                    req.Path = $"API/Departamento/UpdateDepartamentos";
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

        public async Task<ServiceResult> EliminarDepartamento(string Esta_Id)
        {
            var result = new ServiceResult();
            try
            {
                var response = await _api.Delete<DepartamentoViewModel, ServiceResult>(req =>
                {
                    req.Path = $"API/Departamento/DeleteDepartamentos?Esta_Id={Esta_Id}";
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

        public async Task<ServiceResult> DetallesDepartamento(string Esta_Id)
        {
            var result = new ServiceResult();
            try
            {
                var response = await _api.Get<IEnumerable<DepartamentoViewModel>, IEnumerable< DepartamentoViewModel>> (req =>
                {
                    req.Path = $"API/Departamento/DetailsDepartamentos?Esta_Id={Esta_Id}";
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
