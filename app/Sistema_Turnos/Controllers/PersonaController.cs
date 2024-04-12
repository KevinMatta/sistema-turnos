using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Sistema_Turnos.Models;
using Sistema_Turnos.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sistema_Turnos.Controllers
{
    public class PersonaController : Controller
    {

        private readonly PersonaService _personaService;
        public RolService _rolService;
        private readonly EstadoCivilService _estadoCivilService;

        public PersonaController(PersonaService personaService, RolService rolService, EstadoCivilService estadoCivilService)
        {
            _personaService = personaService;
            _rolService = rolService;
            _estadoCivilService = estadoCivilService;
        }

        [HttpGet("Persona/Listado")]
        [ResponseCache(Location = ResponseCacheLocation.None, NoStore = true)]
        public async Task<IActionResult> Index()
        {
            try
            {
                string rol = HttpContext.Session.GetString("roles");

                if (rol == "0")
                {
                    return RedirectToAction("Login", "Home");
                }

                else
                {
                    int valor = 0;
                    if (rol != "")
                    {
                        var url = await _rolService.ValidarUrl(7, int.Parse(rol));
                        var validarurl = url.Data as IEnumerable<RolViewModel>;
                        foreach (var item in validarurl)
                        {
                            int? rol_id = item.Rol_Id;
                            valor = 1;
                        }
                    }

                    if (valor == 1 || HttpContext.Session.GetString("IsAdmin") == "IsAdmin")
                    {
                        var listestadosciviles = await _estadoCivilService.ObtenerEstadoCivilList();
                        var estadocivil = listestadosciviles.Data as IEnumerable<EstadoCivilViewModel>;
                        var estado = estadocivil.ToList().Select(x => new SelectListItem { Text = x.EsCi_Descripcion, Value = x.EsCi_Id.ToString() }).ToList();
                        estado.Insert(0, new SelectListItem { Text = "Seleccione", Value = "1" });
                        ViewBag.estado = estado;

                        var model = new List<PersonaViewModel>();
                        var list = await _personaService.PersonasList();
                        return View(list.Data);
                    }

                    else
                    {
                        return RedirectToAction("Index", "Home");
                    }

                }
            }

            catch (Exception ex)
            {
                return RedirectToAction("Index", "Home");
            }
        }

        [HttpPost("Persona/Create)]
        [ResponseCache(Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Create()
        {

            try
            {
                return View();

            }
            catch (Exception ex)
            {
                return View();
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ResponseCache(Location = ResponseCacheLocation.None, NoStore = true)]
        public async Task<IActionResult> Create(PersonaViewModel item)
        {

            try
            {
                item.Pers_Creacion = int.Parse(HttpContext.Session.GetString("Usua_Id"));
                item.Pers_FechaCreacion = DateTime.Now;
                var list = await _personaService.CrearPersona(item);
                string[] notificaciones = new string[4];
                notificaciones[0] = "tim-icons icon-alert-circle-exc";
                notificaciones[1] = "Agregado";
                notificaciones[2] = "Se agregaron los datos con exito";
                notificaciones[3] = "info";
                TempData["Notificaciones"] = notificaciones;

                return RedirectToAction("Index", "Persona");

                //return View(new List<DepartamentoViewModel> { (DepartamentoViewModel)list.Data } );
            }
            catch (Exception ex)
            {
                return View(item);
            }
        }

        [HttpGet("Persona/Edit/")]
        [ResponseCache(Location = ResponseCacheLocation.None, NoStore = true)]
        public async Task<IActionResult> Edit(string id)
        {
            try
            {
                var listestadosciviles = await _estadoCivilService.ObtenerEstadoCivilList();
                var estadocivil = listestadosciviles.Data as IEnumerable<EstadoCivilViewModel>;
                var estado = estadocivil.ToList().Select(x => new SelectListItem { Text = x.EsCi_Descripcion, Value = x.EsCi_Id.ToString() }).ToList();
                estado.Insert(0, new SelectListItem { Text = "Seleccione", Value = "1" });
                ViewBag.estado = estado;

                var model = await _personaService.ObtenerPersona(id);
                return View(model);
            }
            catch (Exception ex)
            {
                return RedirectToAction("Index", "Persona");
            }
        }

        [HttpPost("Persona/Edit")]
        public async Task<IActionResult> Edit(PersonaViewModel item)
        {

            try
            {
                item.Pers_Modificacion = int.Parse(HttpContext.Session.GetString("Usua_Id"));
                item.Pers_FechaModificacion = DateTime.Now;
                var result = await _personaService.EditarPersona(item);
                if (result.Success)
                {
                    string[] notificaciones = new string[4];
                    notificaciones[0] = "tim-icons icon-alert-circle-exc";
                    notificaciones[1] = "Exito";
                    notificaciones[2] = "Se edito el registro con exito";
                    notificaciones[3] = "info";
                    TempData["Notificaciones"] = notificaciones;
                    return RedirectToAction("Index", "Persona");
                }
                else
                {
                    return RedirectToAction("Index", "Persona");
                }
            }
            catch (Exception ex)
            {
                return RedirectToAction("Index", "Persona");
                throw;
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int Pers_Identidad, int modificacion, DateTime fecha)
        {
            try
            {
                modificacion = int.Parse(HttpContext.Session.GetString("Usua_Id"));
                fecha = DateTime.Now;

                var list = await _personaService.EliminarPersona(Pers_Identidad, modificacion, fecha);
                var hola = list.Message;
                if (hola == "Error al realizar la operacion.")
                {
                    string[] notificaciones = new string[4];
                    notificaciones[0] = "tim-icons icon-bell-55";
                    notificaciones[1] = "Error";
                    notificaciones[2] = "Ocurrio un error al eliminar el empleado";
                    notificaciones[3] = "warning";
                    TempData["Notificaciones"] = notificaciones;
                }
                else
                {
                    string[] notificaciones = new string[4];
                    notificaciones[0] = "tim-icons icon-alert-circle-exc";
                    notificaciones[1] = "Exito";
                    notificaciones[2] = "Se elimino el empleado con exito";
                    notificaciones[3] = "info";
                    TempData["Notificaciones"] = notificaciones;
                }
                return RedirectToAction("Index", "Persona");
            }
            catch (Exception ex)
            {
                return RedirectToAction("Index", "Persona");
            }
        }

        [ResponseCache(Location = ResponseCacheLocation.None, NoStore = true)]
        public async Task<IActionResult> Details(string Pers_Identidad)
        {
            string rol = HttpContext.Session.GetString("roles");

            if (rol == "0")
            {
                return RedirectToAction("Login", "Home");
            }
            else
            {
                var response = await _personaService.DetallesPersona(Pers_Identidad);

                if (response.Success)
                {

                    return View(response.Data);

                }

                else
                {

                    return RedirectToAction("Index", "Persona");
                }
            }
        }

    }
}
