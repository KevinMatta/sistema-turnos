using Sistema_Turnos.Models;
using Sistema_Turnos.WebAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sistema_Turnos.Services
{
    public class MunicipioService
    {
        private readonly API _api;
        public MunicipioService(API api)
        {
            _api = api;
        }

        public async Task<ServiceResult> ObtenerMunicipioList()
        {
            var result = new ServiceResult();
            try
            {
                var response = await _api.Get<IEnumerable<MunicipioViewModel>, IEnumerable<MunicipioViewModel>>(req =>
                {
                    req.Path = $"API/Municipio/ListadoMunicipios";
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

        public async Task<ServiceResult> CrearMunicipio(MunicipioViewModel item)
        {
            var result = new ServiceResult();
            try
            {
                var response = await _api.Post<MunicipioViewModel, ServiceResult>(req =>
                {
                    req.Path = $"API/Municipio/CreateMunicipios";
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

        public async Task<ServiceResult> ObtenerMunicipio(string Ciud_Id)
        {
            var result = new ServiceResult();
            try
            {
                var response = await _api.Get<IEnumerable<MunicipioViewModel>, MunicipioViewModel>(req =>
                {
                    req.Path = $"API/Municipio/FillMunicipio/{Ciud_Id}";
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

        public async Task<ServiceResult> EditarMunicipio(MunicipioViewModel item)
        {
            var result = new ServiceResult();
            try
            {
                var response = await _api.Put<MunicipioViewModel, ServiceResult>(req =>
                {
                    req.Path = $"API/Municipio/UpdateMunicipio";
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

        public async Task<ServiceResult> EliminarMunicipio(string Ciud_Id)
        {
            var result = new ServiceResult();
            try
            {
                var response = await _api.Delete<MunicipioViewModel, ServiceResult>(req =>
                {
                    req.Path = $"API/Municipio/FillMunicipio/{Ciud_Id}";
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

        public async Task<ServiceResult> DetallesMunicipio(string Ciud_Id)
        {
            var result = new ServiceResult();
            try
            {
                var response = await _api.Get<IEnumerable<MunicipioViewModel>, IEnumerable<MunicipioViewModel>>(req =>
                {
                    req.Path = $"API/Municipio/FillMunicipio/{Ciud_Id}";
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
