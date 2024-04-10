using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sistema_Turnos.Models;
using Sistema_Turnos.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sistema_Turnos.Controllers
{
    public class EstadoCivilController : Controller
    {
        private readonly EstadoCivilService _estadoCivilService;
        public RolService _rolService;

        public EstadoCivilController(EstadoCivilService estadoCivilService, RolService rolService)
        {
            _estadoCivilService = estadoCivilService;
            _rolService = rolService;
        }

        [HttpGet("EstadoCivil/Listado")]
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
                        var url = await _rolService.ValidarUrl(4, int.Parse(rol));
                        var validarurl = url.Data as IEnumerable<RolViewModel>;
                        foreach (var item in validarurl)
                        {
                            int? rol_id = item.Rol_Id;
                            valor = 1;
                        }
                    }

                    if (valor == 1 || HttpContext.Session.GetString("rol") == "Administrador")
                    {

                        var model = new List<EstadoCivilViewModel>();
                        var list = await _estadoCivilService.ObtenerEstadoCivilList();
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

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(EstadoCivilViewModel item)
        {

            try
            {
                string cargo = item.EsCi_Descripcion;
                item.EsCi_Creacion = int.Parse(HttpContext.Session.GetString("Usua_Id"));
                item.EsCi_FechaCreacion = DateTime.Now;
                var list = await _estadoCivilService.CrearEstadoCivil(item);
                string[] notificaciones = new string[4];
                notificaciones[0] = "tim-icons icon-alert-circle-exc";
                notificaciones[1] = "Agregado";
                notificaciones[2] = "Se agregaron los datos con exito";
                notificaciones[3] = "info";
                TempData["Notificaciones"] = notificaciones;

                return RedirectToAction("Index", "EstadoCivil");

                //return View(new List<DepartamentoViewModel> { (DepartamentoViewModel)list.Data } );
            }
            catch (Exception ex)
            {
                return View(item);
            }
        }

        [HttpGet("EstadoCivil/Edit{id}")]
        public async Task<IActionResult> Edit(int id)
        {
            try
            {
                var model = await _estadoCivilService.ObtenerEstadoCivil(id);
                return Json(model.Data);
            }
            catch (Exception ex)
            {
                return RedirectToAction("Index", "EstadoCivil");
            }
        }

        [HttpPost("EstadoCivil/Edit")]
        public async Task<IActionResult> Edit(EstadoCivilViewModel item, int EsCi_Id, string EsCi_Descripcion)
        {

            try
            {
                item.EsCi_Id = EsCi_Id;
                item.EsCi_Descripcion = EsCi_Descripcion;
                item.EsCi_Modificacion = int.Parse(HttpContext.Session.GetString("Usua_Id"));
                //item.Ciud_FechaModificacion = DateTime.Now;
                var result = await _estadoCivilService.EditarEstadoCivil(item);
                if (result.Success)
                {
                    string[] notificaciones = new string[4];
                    notificaciones[0] = "tim-icons icon-alert-circle-exc";
                    notificaciones[1] = "Exito";
                    notificaciones[2] = "Se edito el registro con exito";
                    notificaciones[3] = "info";
                    TempData["Notificaciones"] = notificaciones;
                    return RedirectToAction("Index", "EstadoCivil");
                }
                else
                {
                    return RedirectToAction("Index", "EstadoCivil");
                }
            }
            catch (Exception ex)
            {
                return RedirectToAction("Index", "EstadoCivil");
                throw;
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int EsCi_Id, int EsCi_Modificacion, DateTime EsCi_FechaModificacion)
        {
            try
            {
                EsCi_Modificacion = int.Parse(HttpContext.Session.GetString("Usua_Id"));
                EsCi_FechaModificacion = DateTime.Now;

                var list = await _estadoCivilService.EliminarEstadoCivil(EsCi_Id, EsCi_Modificacion, EsCi_FechaModificacion);
                var hola = list.Message;
                if (hola == "Error al realizar la operacion.")
                {
                    string[] notificaciones = new string[4];
                    notificaciones[0] = "tim-icons icon-bell-55";
                    notificaciones[1] = "Error";
                    notificaciones[2] = "Ocurrio un error al eliminar el estado civil";
                    notificaciones[3] = "warning";
                    TempData["Notificaciones"] = notificaciones;
                }
                else
                {
                    string[] notificaciones = new string[4];
                    notificaciones[0] = "tim-icons icon-alert-circle-exc";
                    notificaciones[1] = "Exito";
                    notificaciones[2] = "Se elimino el estado civil con exito";
                    notificaciones[3] = "info";
                    TempData["Notificaciones"] = notificaciones;
                }
                return RedirectToAction("Index", "EstadoCivil");
            }
            catch (Exception ex)
            {
                return RedirectToAction("Index", "EstadoCivil");
            }
        }

        [ResponseCache(Location = ResponseCacheLocation.None, NoStore = true)]
        public async Task<IActionResult> Details(int EsCi_Id)
        {
            string rol = HttpContext.Session.GetString("roles");

            if (rol == "0")
            {
                return RedirectToAction("Login", "Home");
            }
            else
            {
                var response = await _estadoCivilService.DetallesEstadoCivil(EsCi_Id);

                if (response.Success)
                {

                    return View(response.Data);

                }

                else
                {

                    return RedirectToAction("Index", "EstadoCivil");
                }
            }
        }

    }
}
