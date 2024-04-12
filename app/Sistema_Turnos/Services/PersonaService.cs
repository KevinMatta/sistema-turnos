using Sistema_Turnos.Models;
using Sistema_Turnos.WebAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sistema_Turnos.Services
{
    public class PersonaService
    {

        private readonly API _api;
        public PersonaService(API api)
        {
            _api = api;
        }

        public async Task<ServiceResult> PersonasList()
        {
            var result = new ServiceResult();
            try
            {
                var response = await _api.Get<IEnumerable<PersonaViewModel>, IEnumerable<PersonaViewModel>>(req =>
                {
                    req.Path = $"API/Persona/ListadoPersonas";
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

        public async Task<ServiceResult> CrearPersona(PersonaViewModel item)
        {
            var result = new ServiceResult();
            try
            {
                var response = await _api.Post<PersonaViewModel, ServiceResult>(req =>
                {
                    req.Path = $"API/Persona/CreatePersonas";
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

        public async Task<ServiceResult> ObtenerPersona(string Pers_Identidad)
        {
            var result = new ServiceResult();
            try
            {
                var response = await _api.Get<IEnumerable<PersonaViewModel>, PersonaViewModel>(req =>
                {
                    req.Path = $"API/Persona/FillPersonas/{Pers_Identidad}";
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

        public async Task<ServiceResult> EditarPersona(PersonaViewModel item)
        {
            var result = new ServiceResult();
            try
            {
                var response = await _api.Put<PersonaViewModel, ServiceResult>(req =>
                {
                    req.Path = $"API/Persona/UpdatePersonas";
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

        public async Task<ServiceResult> EliminarPersona(string id, int modificacion, DateTime fecha)
        {
            var result = new ServiceResult();
            try
            {
                var response = await _api.Delete<PersonaViewModel, ServiceResult>(req =>
                {
                    req.Path = $"API/Persona/DeletePersonas?id={id}&modificacion={modificacion}&fecha={fecha}";
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

        public async Task<ServiceResult> DetallesPersona(string Pers_Identidad)
        {
            var result = new ServiceResult();
            try
            {
                var response = await _api.Get<IEnumerable<PersonaViewModel>, IEnumerable<PersonaViewModel>>(req =>
                {
                    req.Path = $"API/Persona/FillPersonas/{Pers_Identidad}";
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
