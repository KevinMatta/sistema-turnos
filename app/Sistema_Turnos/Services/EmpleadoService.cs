using Sistema_Turnos.Models;
using Sistema_Turnos.WebAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sistema_Turnos.Services
{
    public class EmpleadoService
    {
        private readonly API _api;

        public EmpleadoService(API api)
        {
            _api = api;
        }

        public async Task<ServiceResult> EmpleadosList()
        {
            var result = new ServiceResult();
            try
            {
                var response = await _api.Get<IEnumerable<EmpleadoViewModel>, IEnumerable<EmpleadoViewModel>>(req =>
                {
                    req.Path = $"API/Empleado/ListarEmpledos";
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

        public async Task<ServiceResult> CrearEmpleado(EmpleadoViewModel item)
        {
            var result = new ServiceResult();
            try
            {
                var response = await _api.Post<EmpleadoViewModel, ServiceResult>(req =>
                {
                    req.Path = $"API/Empleado/CreateEmpleados";
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

        public async Task<ServiceResult> ObtenerEmpleado(int Empl_Id)
        {
            var result = new ServiceResult();
            try
            {
                var response = await _api.Get<IEnumerable<EmpleadoViewModel>, EmpleadoViewModel>(req =>
                {
                    req.Path = $"API/Empleado/FillEmpleados{Empl_Id}";
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

        public async Task<ServiceResult> EditarEmpleado(EmpleadoViewModel item)
        {
            var result = new ServiceResult();
            try
            {
                var response = await _api.Put<EmpleadoViewModel, ServiceResult>(req =>
                {
                    req.Path = $"API/Empleado/UpdateEmpleados";
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

        public async Task<ServiceResult> EliminarEmpleado(int id, int modificacion, DateTime fecha)
        {
            var result = new ServiceResult();
            try
            {
                var response = await _api.Delete<EmpleadoViewModel, ServiceResult>(req =>
                {
                    req.Path = $"API/Empleado/DeleteEmpleados?id={id}&modificacion={modificacion}&fecha={fecha}";
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

        public async Task<ServiceResult> DetallesEmpelado(int Empl_Id)
        {
            var result = new ServiceResult();
            try
            {
                var response = await _api.Get<IEnumerable<EmpleadoViewModel>, IEnumerable<EmpleadoViewModel>>(req =>
                {
                    req.Path = $"API/Empleado/FillEmpleados{Empl_Id}";
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
