using Sistema_Turnos.Models;
using Sistema_Turnos.WebAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sistema_Turnos.Services
{
    public class HospitalService
    {
        private readonly API _api;
        public HospitalService(API api)
        {
            _api = api;
        }

        public async Task<ServiceResult> ObtenerHospitalList()
        {
            var result = new ServiceResult();
            try
            {
                var response = await _api.Get<IEnumerable<HospitalViewModel>, IEnumerable<HospitalViewModel>>(req =>
                {
                    req.Path = $"API/Hospitales/ListTurnosHospitales";
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

        public async Task<ServiceResult> CrearHospital(HospitalViewModel item)
        {
            var result = new ServiceResult();
            try
            {
                var response = await _api.Post<HospitalViewModel, ServiceResult>(req =>
                {
                    req.Path = $"API/Hospitales/CreateHospitales";
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

        public async Task<ServiceResult> ObtenerHospital(int Carg_Id)
        {
            var result = new ServiceResult();
            try
            {
                var response = await _api.Get<IEnumerable<HospitalViewModel>, HospitalViewModel>(req =>
                {
                    req.Path = $"API/Hospitales/FillHospitales/{Carg_Id}";
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

        public async Task<ServiceResult> EditarHospital(HospitalViewModel item)
        {
            var result = new ServiceResult();
            try
            {
                var response = await _api.Put<HospitalViewModel, ServiceResult>(req =>
                {
                    req.Path = $"API/Hospitales/UpdateHospitales";
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

        public async Task<ServiceResult> EliminarHospital(int id, int modificacion, DateTime fecha)
        {
            var result = new ServiceResult();
            try
            {
                var response = await _api.Delete<HospitalViewModel, ServiceResult>(req =>
                {
                    req.Path = $"API/Hospitales/DeleteHospitales?id={id}&modificacion={modificacion}&fecha={fecha}";
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

        public async Task<ServiceResult> DetallesHospital(int id)
        {
            var result = new ServiceResult();
            try
            {
                var response = await _api.Get<IEnumerable<HospitalViewModel>, IEnumerable<HospitalViewModel>>(req =>
                {
                    req.Path = $"API/Hospitales/FillHospitales/{id}";
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
