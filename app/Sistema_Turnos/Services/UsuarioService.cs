using Sistema_Turnos.Models;
using Sistema_Turnos.WebAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sistema_Turnos.Services
{
    public class UsuarioService
    {
        private readonly API _api;

        public UsuarioService(API api)
        {
            _api = api;
        }

        public async Task<ServiceResult> ObtenerUsuarioList()
        {
            var result = new ServiceResult();
            try
            {
                var response = await _api.Get<IEnumerable<UsuarioViewModel>, IEnumerable<UsuarioViewModel>>(req =>
                {
                    req.Path = $"API/Usuario/ListadoUsuarios";
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

        public async Task<ServiceResult> CrearUsuario(UsuarioViewModel item)
        {
            var result = new ServiceResult();
            try
            {
                var response = await _api.Post<UsuarioViewModel, ServiceResult>(req =>
                {
                    req.Path = $"API/Usuario/CreateUsuarios";
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

        public async Task<ServiceResult> ObtenerUsuario(int Usua_Id)
        {
            var result = new ServiceResult();
            try
            {
                var response = await _api.Get<IEnumerable<UsuarioViewModel>, CargoViewModel>(req =>
                {
                    req.Path = $"API/Usuario/FillUsuarios/{Usua_Id}";
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

        public async Task<ServiceResult> EditarUsuario(UsuarioViewModel item)
        {
            var result = new ServiceResult();
            try
            {
                var response = await _api.Put<UsuarioViewModel, ServiceResult>(req =>
                {
                    req.Path = $"API/Usuario/UpdateUsuarios";
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

        public async Task<ServiceResult> EliminarUsuario(int Usua_Id, int Usua_Modificacion, DateTime Usua_FechaModificacion)
        {
            var result = new ServiceResult();
            try
            {
                var response = await _api.Delete<UsuarioViewModel, ServiceResult>(req =>
                {
                    req.Path = $"API/Usuario/DeleteUsuarios?id={Usua_Id}&usuario={Usua_Modificacion}&fecha={Usua_FechaModificacion}";
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

        public async Task<ServiceResult> DetallesUsuario(int Usua_Id)
        {
            var result = new ServiceResult();
            try
            {
                var response = await _api.Get<IEnumerable<UsuarioViewModel>, IEnumerable<UsuarioViewModel>>(req =>
                {
                    req.Path = $"API/Usuario/FillUsuarios/{Usua_Id}";
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

        public async Task<ServiceResult> Restablecer(int Usua_Id, string Usua_Clave, int Usua_Modificacion, DateTime Usua_FechaModificacion)
        {
            var result = new ServiceResult();
            try
            {
                var response = await _api.Post<UsuarioViewModel, ServiceResult>(req =>
                {
                    req.Path = $"API/Usuario/DeleteUsuarios?Usua_Id={Usua_Id}&Usua_Clave={Usua_Clave}&Usua_Modificacion={Usua_Modificacion}&Usua_FechaModificacion={Usua_FechaModificacion}";
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

        public async Task<ServiceResult> Login(string Usuario, string Contra)
        {
            var result = new ServiceResult();
            try
            {
                var response = await _api.Get<IEnumerable<UsuarioViewModel>, IEnumerable<UsuarioViewModel>>(req =>
                {
                    req.Path = $"API/Home/LoginHome?Usuario={Usuario}&Contra={Contra}";
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

        public async Task<ServiceResult> ValidarUsuario(string Usuario)
        {
            var result = new ServiceResult();
            try
            {
                var response = await _api.Get<IEnumerable<UsuarioViewModel>, IEnumerable<UsuarioViewModel>>(req =>
                {
                    req.Path = $"API/Home/ValidarUsuarioHome?Usuario={Usuario}";
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

        public async Task<ServiceResult> ValidarClave(string Contra)
        {
            var result = new ServiceResult();
            try
            {
                var response = await _api.Get<IEnumerable<UsuarioViewModel>, IEnumerable<UsuarioViewModel>>(req =>
                {
                    req.Path = $"API/Home/ValidarClaveHome?Contra={Contra}";
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
