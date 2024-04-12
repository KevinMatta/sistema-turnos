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
    public class TurnoController : Controller
    {

        public readonly TurnoService _turnoService;
        public RolService _rolService;
        public TurnoController(TurnoService turnoService, RolService rolService)
        {
            _rolService = rolService;
            _turnoService = turnoService;
        }

        [HttpGet("Turno/Listado")]
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

                        var model = new List<TurnoViewModel>();
                        var list = await _turnoService.TurnosList();
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

        // POST: MunicipioController/CreateDepartamentos
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(TurnoViewModel item)
        {

            try
            {
                item.Turn_Creacion = int.Parse(HttpContext.Session.GetString("Usua_Id"));
                item.Turn_FechaCreacion = DateTime.Now;
                var list = await _turnoService.CrearTurno(item);
                string[] notificaciones = new string[4];
                notificaciones[0] = "tim-icons icon-alert-circle-exc";
                notificaciones[1] = "Agregado";
                notificaciones[2] = "Se agregaron los datos con exito";
                notificaciones[3] = "info";
                TempData["Notificaciones"] = notificaciones;

                return RedirectToAction("Index", "Turno");

                //return View(new List<DepartamentoViewModel> { (DepartamentoViewModel)list.Data } );
            }
            catch (Exception ex)
            {
                return View(item);
            }
        }

        [HttpGet("Turno/Edit{id}")]
        public async Task<IActionResult> Edit(int id)
        {
            try
            {
                var model = await _turnoService.ObtenerTurno(id);
                return Json(model.Data);
            }
            catch (Exception ex)
            {
                return RedirectToAction("Index", "Turno");
            }
        }

        [HttpPost("Turno/Edit")]
        public async Task<IActionResult> Edit(TurnoViewModel item, int Turn_Id , string Turn_HoraEntrada, string Turn_HoraSalida)
        {

            try
            {
                item.Turn_Id = Turn_Id;
                item.Turn_HoraEntrada = Turn_HoraEntrada;
                item.Turn_HoraSalida = Turn_HoraSalida;
                item.Turn_Modificacion =  int.Parse(HttpContext.Session.GetString("Usua_Id"));
                item.Turn_FechaModificacion = DateTime.Now;
                var result = await _turnoService.EditarTurno(item);
                if (result.Success)
                {
                    string[] notificaciones = new string[4];
                    notificaciones[0] = "tim-icons icon-alert-circle-exc";
                    notificaciones[1] = "Exito";
                    notificaciones[2] = "Se edito el registro con exito";
                    notificaciones[3] = "info";
                    TempData["Notificaciones"] = notificaciones;
                    return RedirectToAction("Index", "Turno");
                }
                else
                {
                    return RedirectToAction("Index", "Turno");
                }
            }
            catch (Exception ex)
            {
                return RedirectToAction("Index", "Turno");
                throw;
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int Turn_Id, int modificacion, DateTime fecha)
        {
            try
            {
                modificacion = int.Parse(HttpContext.Session.GetString("Usua_Id"));
                fecha = DateTime.Now;

                var list = await _turnoService.EliminarTurno(Turn_Id, modificacion, fecha);
                var hola = list.Message;
                if (hola == "Error al realizar la operacion.")
                {
                    string[] notificaciones = new string[4];
                    notificaciones[0] = "tim-icons icon-bell-55";
                    notificaciones[1] = "Error";
                    notificaciones[2] = "Ocurrio un error al eliminar el turno";
                    notificaciones[3] = "warning";
                    TempData["Notificaciones"] = notificaciones;
                }
                else
                {
                    string[] notificaciones = new string[4];
                    notificaciones[0] = "tim-icons icon-alert-circle-exc";
                    notificaciones[1] = "Exito";
                    notificaciones[2] = "Se elimino el turno con exito";
                    notificaciones[3] = "info";
                    TempData["Notificaciones"] = notificaciones;
                }
                return RedirectToAction("Index", "Turno");
            }
            catch (Exception ex)
            {
                return RedirectToAction("Index", "Turno");
            }
        }

        [ResponseCache(Location = ResponseCacheLocation.None, NoStore = true)]
        public async Task<IActionResult> Details(int Turn_Id)
        {
            string rol = HttpContext.Session.GetString("roles");

            if (rol == "0")
            {
                return RedirectToAction("Login", "Home");
            }
            else
            {
                var response = await _turnoService.DetallesTurno(Turn_Id);

                if (response.Success)
                {

                    return View(response.Data);

                }

                else
                {

                    return RedirectToAction("Index", "Turno");
                }
            }
        }

    }
}
