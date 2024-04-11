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
                    req.Path = $"API/Turno/Listar";
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
