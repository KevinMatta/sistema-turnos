using Sistema_Turnos.Models;
using Sistema_Turnos.WebAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Sistema_Turnos.Controllers;
using Microsoft.AspNetCore.Mvc;
using Sistema_Turnos.Clases;

namespace Sistema_Turnos.Services
{
    public class RolService
    {
        private readonly API _api;

        public RolService(API api)
        {
            _api = api;
        }

        public async Task<ServiceResult> ObtenerRolList()
        {
            var result = new ServiceResult();
            try
            {
                var response = await _api.Get<IEnumerable<RolViewModel>, IEnumerable<RolViewModel>>(req =>
                {
                    req.Path = $"API/Rol/ListadoRoles";
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

        public async Task<ServiceResult> CrearRoles(RolViewModel item)
        {
            var result = new ServiceResult();
            try
            {
                var response = await _api.Post<RolViewModel, ServiceResult>(req =>
                {
                    req.Path = $"API/Rol/CreatePantalla";
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
        public async Task<ServiceResult> ObtenerPantallaList()
        {
            var result = new ServiceResult();
            try
            {
                var response = await _api.Get<IEnumerable<PantallaViewModel>, IEnumerable<PantallaViewModel>>(req =>
                {
                    req.Path = $"API/Rol/CreatePantalla";
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

        public async Task<ServiceResult> EditarRol(int Rol_id)
        {
            var result = new ServiceResult();
            try
            {
                var response = await _api.Get<IEnumerable<RolViewModel>, IEnumerable<RolViewModel>>(req =>
                {
                    req.Path = $"API/Rol/UpdateRol?Rol_id={Rol_id}";
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

        public async Task<ServiceResult> EditRoles([FromBody] FormData formData)
        {
            var result = new ServiceResult();
            try
            {
                var response = await _api.Post<FormData, ServiceResult>(req =>
                {
                    req.Path = $"API/Rol/UpdateRol";
                    req.Content = formData;
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

        public async Task<ServiceResult> ValidarUrl(int Pant_Id, int Rol_Id)
        {
            var result = new ServiceResult();
            try
            {
                var response = await _api.Get<IEnumerable<RolViewModel>, IEnumerable<RolViewModel>>(req =>
                {
                    req.Path = $"API/Rol/ValidarUrl?Pant_Id={Pant_Id}&Rol_Id={Rol_Id}";
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

        public async Task<ServiceResult> EliminarRol(int Rol_Id)
        {
            var result = new ServiceResult();
            try
            {
                var response = await _api.Delete<DepartamentoViewModel, ServiceResult>(req =>
                {
                    req.Path = $"API/Rol/DeleteRol?Rol_Id={Rol_Id}";
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
