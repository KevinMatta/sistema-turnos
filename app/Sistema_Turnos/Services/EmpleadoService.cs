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
                    req.Path = $"API/Empleado/Listar";
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
