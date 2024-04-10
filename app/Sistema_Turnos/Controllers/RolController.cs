using Microsoft.AspNetCore.Mvc;
using Sistema_Turnos.Models;
using Sistema_Turnos.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;
using Sistema_Turnos.Clases;
using Microsoft.AspNetCore.Http;

namespace Sistema_Turnos.Controllers
{
    public class RolController : Controller
    {
        public RolService _rolService;
        private object httpClient;

        public RolController(RolService rolService)
        {
            _rolService = rolService;
        }

        [HttpGet("RolListado")]
        [ResponseCache(Location = ResponseCacheLocation.None, NoStore = true)]
        public async Task<IActionResult> Index()
        {
            try
            {
                var list = await _rolService.ObtenerRolList();
                return View(list.Data);
            }
            catch (Exception ex)
            {
                return RedirectToAction("Index", "Home");
            }
        }

        [HttpGet("CreatePantalla")]
        [ResponseCache(Location = ResponseCacheLocation.None, NoStore = true)]
        public async Task<IActionResult> Create()
        {
            try
            {
                var model = new List<PantallaViewModel>();
                var list = await _rolService.ObtenerPantallaList();
                return View(list.Data);
            }
            catch (Exception ex)
            {
                return RedirectToAction("Index", "Home");
            }
        }

        [HttpPost("CreatePantalla")]
        public async Task<IActionResult> Create(RolViewModel item)
        {
            try
            {
                var list = await _rolService.CrearRoles(item);
                string[] notificaciones = new string[4];
                notificaciones[0] = "tim-icons icon-alert-circle-exc";
                notificaciones[1] = "Agregado";
                notificaciones[2] = "Se agregaron los datos con exito";
                notificaciones[3] = "info";
                TempData["Notificaciones"] = notificaciones;

                return RedirectToAction("Index");
                //return View(new List<DepartamentoViewModel> { (DepartamentoViewModel)list.Data } );
            }
            catch (Exception ex)
            {
                return View(item);
            }
        }

        [HttpGet("UpdateRol")]
        [ResponseCache(Location = ResponseCacheLocation.None, NoStore = true)]
        public async Task<IActionResult> Edit(int Rol_Id)
        {
            HttpContext.Session.SetString("rolll", Rol_Id.ToString());

            try
            {
                var apiUrl = "https://localhost:44363/API/Rol/UpdateRol?Rol_id=" + Rol_Id; // URL de tu API
                using (var httpClient = new HttpClient())
                {
                    var response = await httpClient.GetAsync(apiUrl);

                    if (response.IsSuccessStatusCode)
                    {
                        var content = await response.Content.ReadAsStringAsync();
                        var rolData = JsonConvert.DeserializeObject<RolViewModel>(content); // Deserializar el contenido JSON en tu modelo
                        return View(rolData);
                    }
                    else
                    {
                        // Manejar el caso en que la solicitud no sea exitosa
                        // Por ejemplo, redireccionar a una página de error
                        return RedirectToAction("Error", "Home");
                    }
                }
            }
            catch (Exception ex)
            {
                return RedirectToAction("Error", "Home");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete([FromForm] int Rol_Id)
        {
            try
            {
                var list = await _rolService.EliminarRol(Rol_Id);
                var hola = list.Message;
                if (hola == "Error al realizar la operacion.")
                {
                    string[] notificaciones = new string[4];
                    notificaciones[0] = "tim-icons icon-alert-circle-exc";
                    notificaciones[1] = "Error";
                    notificaciones[2] = "Ocurrio un error al eliminar el rol";
                    notificaciones[3] = "danger";
                    TempData["Notificaciones"] = notificaciones;
                }
                else
                {
                    string[] notificaciones = new string[4];
                    notificaciones[0] = "tim-icons icon-alert-circle-exc";
                    notificaciones[1] = "Exito";
                    notificaciones[2] = "Se elimino el rol con exito";
                    notificaciones[3] = "info";
                    TempData["Notificaciones"] = notificaciones;
                }
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return RedirectToAction("Index");
            }
        }

    }
}
