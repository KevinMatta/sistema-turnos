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
    public class TurnosPorEmpleadoController : Controller
    {
        public TurnosPorEmpleadoService _turnosPorEmpleadoService;
        public TurnoService _turnoService;
        public EmpleadoService _empleadoService;
        public RolService _rolService;
        public TurnosPorEmpleadoController(TurnosPorEmpleadoService turnosPorEmpleadoService, TurnoService turnoService, EmpleadoService empleadoService, RolService rolService)
        {
            _turnosPorEmpleadoService = turnosPorEmpleadoService;
            _turnoService = turnoService;
            _empleadoService = empleadoService;
            _rolService = rolService;
        }
        [HttpGet("ListTurnosEmpleados")]
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
                        var url = await _rolService.ValidarUrl(11, int.Parse(rol));
                        var validarurl = url.Data as IEnumerable<RolViewModel>;
                        foreach (var item in validarurl)
                        {
                            int? rol_id = item.Rol_Id;
                            valor = 1;
                        }
                    }

                    if (valor == 1 || HttpContext.Session.GetString("IsAdmin") == "IsAdmin")
                    {

                        var listaempleado = await _empleadoService.EmpleadosList();
                        var emplea = listaempleado.Data as IEnumerable<EmpleadoViewModel>;
                        var emple = emplea.ToList().Select(x => new SelectListItem { Text = x.Nombre, Value = x.Empl_Id.ToString() }).ToList();
                        emple.Insert(0, new SelectListItem { Text = "Seleccione", Value = "1" });
                        ViewBag.Empleados = emple;

                        var list = await _turnosPorEmpleadoService.TurnosPorEmpleadoList();
                        var empleados = await _empleadoService.EmpleadosList();
                        var turnos = await _turnoService.TurnosList();

                        ViewBag.ListaEmpleados = empleados.Data;
                        ViewBag.ListaTurnos = turnos.Data;
                        ViewBag.ListaTurnoEmpleado = list.Data;

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
                return RedirectToAction("Index", "TurnosPorEmpleado");
            }
        }

        [HttpPost("TurnosPorEmpleado/Crear")]
        public async Task<IActionResult> Create(TurnosPorEmpleadoViewModel item)
        {
            try
            {
                var listaTurnosEmpleado = new List<TurnosPorEmpleadoViewModel>();
                var listaTurnosEmpleadoResponse = await _turnosPorEmpleadoService.TurnosPorEmpleadoList();
                listaTurnosEmpleado = (List<TurnosPorEmpleadoViewModel>)listaTurnosEmpleadoResponse.Data;
                DateTime fechaSeleccionada = item.TuEm_FechaInicio;

                var mismoDia = listaTurnosEmpleado.Where(t => t.TuEm_FechaInicio.Date == fechaSeleccionada).ToList();

                var turnoNocturno = listaTurnosEmpleado.Where(t =>
                    (t.TuEm_FechaInicio.Date == fechaSeleccionada.AddDays(-2) ||
                    t.TuEm_FechaInicio.Date == fechaSeleccionada.AddDays(2)) &&
                    t.Turn_Id == 3).ToList();

                DateTime inicioSemana = fechaSeleccionada.Date.AddDays(-(int)fechaSeleccionada.DayOfWeek);
                DateTime finSemana = inicioSemana.AddDays(6);

                var turnosSemana = listaTurnosEmpleado.Where(t =>
                    t.TuEm_FechaInicio.Date >= inicioSemana &&
                    t.TuEm_FechaInicio.Date <= finSemana &&
                    t.Turn_Id == 3).ToList();

                var semanaPasada = listaTurnosEmpleado.Where(t =>
                    (t.TuEm_FechaInicio.Date == fechaSeleccionada.AddDays(-7) ||
                    t.TuEm_FechaInicio.Date == fechaSeleccionada.AddDays(7)) &&
                    t.Empl_Id == item.Empl_Id).ToList();

                if (turnosSemana.Count(t => t.Turn_Id == 3) > 2)
                {
                    string[] notificaciones = new string[4];
                    notificaciones[0] = "tim-icons icon-bell-55";
                    notificaciones[1] = "Advertencia";
                    notificaciones[2] = "No puedes asignar este turno mas de 2 veces a la semana";
                    notificaciones[3] = "warning";
                    TempData["Notificaciones"] = notificaciones;
                    return RedirectToAction("Index", "TurnosPorEmpleado");
                }

                if (semanaPasada.Any(t => t.Empl_Id == item.Empl_Id))
                {
                    string[] notificaciones = new string[4];
                    notificaciones[0] = "tim-icons icon-bell-55";
                    notificaciones[1] = "Advertencia";
                    notificaciones[2] = "Este empleado ya tuvo este turno la semana pasada";
                    notificaciones[3] = "warning";
                    return RedirectToAction("Index", "TurnosPorEmpleado");
                }

                if (mismoDia.Any(t => t.Empl_Id == item.Empl_Id))
                {
                    string[] notificaciones = new string[4];
                    notificaciones[0] = "tim-icons icon-bell-55";
                    notificaciones[1] = "Advertencia";
                    notificaciones[2] = "Este empleado ya tiene un turno para este dia";
                    notificaciones[3] = "warning";
                    TempData["Notificaciones"] = notificaciones;
                    return RedirectToAction("Index", "TurnosPorEmpleado");
                }

                if (turnoNocturno.Any(t => t.Empl_Id == item.Empl_Id))
                {
                    string[] notificaciones = new string[4];
                    notificaciones[0] = "tim-icons icon-bell-55";
                    notificaciones[1] = "Advertencia";
                    notificaciones[2] = "No puede tener este turno 2 dias seguidos";
                    notificaciones[3] = "warning";
                    TempData["Notificaciones"] = notificaciones;
                    return RedirectToAction("Index", "TurnosPorEmpleado");
                }

                if (ModelState.IsValid)
                {
                    //listo para insertar
                    item.TuEm_Creacion = 1;
                    item.TuEm_FechaCreacion = DateTime.Now;
                    var list = await _turnosPorEmpleadoService.CrearTurnoEmpleado(item);
                    string[] notificaciones = new string[4];
                    notificaciones[0] = "tim-icons icon-check-2";
                    notificaciones[1] = "Exito";
                    notificaciones[2] = "Se agregaron los datos con exito";
                    notificaciones[3] = "success";
                    TempData["Notificaciones"] = notificaciones;
                }

                return RedirectToAction("Index", "TurnosPorEmpleado");
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = "error" });
            }
        }

        [HttpPost("TurnosPorEmpleado/Editar/{TuEm_Id}/{TuEm_FechaInicio}/{Empl_Id}")]
        public async Task<IActionResult> Editar(int TuEm_Id, DateTime TuEm_FechaInicio, int Empl_Id)
        {
            try
            {
                var item = new TurnosPorEmpleadoViewModel();
                item.TuEm_Id = TuEm_Id;
                item.TuEm_FechaInicio = TuEm_FechaInicio;
                item.Empl_Id = Empl_Id;

                var listaTurnosEmpleado = new List<TurnosPorEmpleadoViewModel>();
                var listaTurnosEmpleadoResponse = await _turnosPorEmpleadoService.TurnosPorEmpleadoList();
                listaTurnosEmpleado = (List<TurnosPorEmpleadoViewModel>)listaTurnosEmpleadoResponse.Data;
                DateTime fechaSeleccionada = item.TuEm_FechaInicio;

                var mismoDia = listaTurnosEmpleado.Where(t => t.TuEm_FechaInicio.Date == fechaSeleccionada).ToList();

                var turnoNocturno = listaTurnosEmpleado.Where(t =>
                    (t.TuEm_FechaInicio.Date == fechaSeleccionada.AddDays(-2) ||
                    t.TuEm_FechaInicio.Date == fechaSeleccionada.AddDays(2)) &&
                    t.Turn_Id == 3).ToList();

                DateTime inicioSemana = fechaSeleccionada.Date.AddDays(-(int)fechaSeleccionada.DayOfWeek);
                DateTime finSemana = inicioSemana.AddDays(6);

                var turnosSemana = listaTurnosEmpleado.Where(t =>
                    t.TuEm_FechaInicio.Date >= inicioSemana &&
                    t.TuEm_FechaInicio.Date <= finSemana &&
                    t.Turn_Id == 3).ToList();

                var semanaPasada = listaTurnosEmpleado.Where(t =>
                    (t.TuEm_FechaInicio.Date == fechaSeleccionada.AddDays(-7) ||
                    t.TuEm_FechaInicio.Date == fechaSeleccionada.AddDays(7)) &&
                    t.Empl_Id == item.Empl_Id).ToList();

                if (turnosSemana.Count(t => t.Turn_Id == 3) > 2)
                {
                    string[] notificaciones = new string[4];
                    notificaciones[0] = "tim-icons icon-bell-55";
                    notificaciones[1] = "Advertencia";
                    notificaciones[2] = "Este empleado ya tuvo este turno esta semana";
                    notificaciones[3] = "warning";
                    TempData["Notificaciones"] = notificaciones;
                    return Json(new { success = false, message = "error" });
                }

                if (semanaPasada.Any(t => t.Empl_Id == item.Empl_Id))
                {
                    string[] notificaciones = new string[4];
                    notificaciones[0] = "tim-icons icon-bell-55";
                    notificaciones[1] = "Advertencia";
                    notificaciones[2] = "Este empleado ya tuvo este turno la semana pasada";
                    notificaciones[3] = "warning";
                    TempData["Notificaciones"] = notificaciones; 
                    return Json(new { success = false, message = "error" });
                }

                if (mismoDia.Any(t => t.Empl_Id == item.Empl_Id))
                {
                    string[] notificaciones = new string[4];
                    notificaciones[0] = "tim-icons icon-bell-55";
                    notificaciones[1] = "Advertencia";
                    notificaciones[2] = "Este empleado ya tiene un turno para este dia";
                    notificaciones[3] = "warning";
                    TempData["Notificaciones"] = notificaciones;
                    return Json(new { success = false, message = "error" });
                }

                if (turnoNocturno.Any(t => t.Empl_Id == item.Empl_Id))
                {
                    string[] notificaciones = new string[4];
                    notificaciones[0] = "tim-icons icon-bell-55";
                    notificaciones[1] = "Advertencia";
                    notificaciones[2] = "No puede tener este turno 2 dias seguidos";
                    notificaciones[3] = "warning";
                    TempData["Notificaciones"] = notificaciones;
                    return Json(new { success = false, message = "error" });
                }


                {
                    //listo para actualizar
                    item.TuEm_Modificacion = 1;
                    item.TuEm_FechaModificacion = DateTime.Now;
                    var list = await _turnosPorEmpleadoService.EditarTurnoEmpleado(item);
                    string[] notificaciones = new string[4];
                    notificaciones[0] = "tim-icons icon-check-2";
                    notificaciones[1] = "Exito";
                    notificaciones[2] = "Se actualizo la fecha con exito";
                    notificaciones[3] = "success";
                    TempData["Notificaciones"] = notificaciones;
                }

                return Json(new { success = false, message = "error" });
            }
            catch (Exception ex)
            {
                return RedirectToAction("Index", "TurnosPorEmpleado");
            }
        }

        [HttpPost("TurnosPorEmpleado/Eliminar")]
        public async Task<IActionResult> Eliminar(int TuEm_Id)
        {
            try
            {
                var list = await _turnosPorEmpleadoService.EliminarTurnoEmpleado(TuEm_Id);
                if (!list.Success)
                {
                    string[] notificaciones = new string[4];
                    notificaciones[0] = "tim-icons icon-alert-circle-exc";
                    notificaciones[1] = "Error";
                    notificaciones[2] = "Ocurrio un error al eliminar el turno";
                    notificaciones[3] = "danger";
                    TempData["Notificaciones"] = notificaciones;
                }
                else
                {
                    string[] notificaciones = new string[4];
                    notificaciones[0] = "tim-icons icon-check-2";
                    notificaciones[1] = "Exito";
                    notificaciones[2] = "Se elimino el turno con exito";
                    notificaciones[3] = "success";
                    TempData["Notificaciones"] = notificaciones;
                }
                return RedirectToAction("Index");
                //return View(new List<DepartamentoViewModel> { (DepartamentoViewModel)list.Data } );
            }
            catch (Exception ex)
            {
                return RedirectToAction("Index");
            }
        }

        [HttpGet("TurnosEmpleaodos/Graficos")]
        [ResponseCache(Location = ResponseCacheLocation.None, NoStore = true)]
        public async Task <IActionResult> Graficos()
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

                    var url = await _rolService.ValidarUrl(13, int.Parse(rol));
                    var validarurl = url.Data as IEnumerable<RolViewModel>;
                    foreach (var item in validarurl)
                    {
                        int? rol_id = item.Rol_Id;
                        valor = 1;
                    }
                }

                if(valor == 1 || HttpContext.Session.GetString("IsAdmin") == "IsAdmin")
                {
                    var listaempleado = await _empleadoService.EmpleadosList();
                    var emplea = listaempleado.Data as IEnumerable<EmpleadoViewModel>;
                    var emple = emplea.ToList().Select(x => new SelectListItem { Text = x.Nombre, Value = x.Empl_Id.ToString() }).ToList();
                    emple.Insert(0, new SelectListItem { Text = "Seleccione", Value = "1" });
                    ViewBag.Empleados = emple;
                    return View();
                }

                else
                {
                    return RedirectToAction("Index", "Home");
                }

            }
        }

    }
}
