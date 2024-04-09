using Microsoft.AspNetCore.Mvc;
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
        public TurnosPorEmpleadoController(TurnosPorEmpleadoService turnosPorEmpleadoService, TurnoService turnoService, EmpleadoService empleadoService)
        {
            _turnosPorEmpleadoService = turnosPorEmpleadoService;
            _turnoService = turnoService;
            _empleadoService = empleadoService;
        }
        [HttpGet("ListTurnosEmpleados")]
        public async Task<IActionResult> Index()
        {
            try
            {
                var list = await _turnosPorEmpleadoService.TurnosPorEmpleadoList();

                var empleados = await _empleadoService.EmpleadosList();
                var turnos = await _turnoService.TurnosList();

                ViewBag.ListaEmpleados = empleados.Data;
                ViewBag.ListaTurnos = turnos.Data;
                ViewBag.ListaTurnoEmpleado = list.Data;

                return View(list.Data);
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
                    (t.TuEm_FechaInicio.Date == fechaSeleccionada.AddDays(-1) ||
                    t.TuEm_FechaInicio.Date == fechaSeleccionada.AddDays(1)) &&
                    t.Turn_Id == 3).ToList();

                var semanaPasada = listaTurnosEmpleado.Where(t =>
                    (t.TuEm_FechaInicio.Date == fechaSeleccionada.AddDays(-7) ||
                    t.TuEm_FechaInicio.Date == fechaSeleccionada.AddDays(7)) &&
                    t.Turn_Id == item.Turn_Id).ToList();

                if (semanaPasada.Any(t => t.Empl_Id == item.Empl_Id))
                {
                    string[] notificaciones = new string[4];
                    notificaciones[0] = "tim-icons icon-bell-55";
                    notificaciones[1] = "Advertencia";
                    notificaciones[2] = "Este empleado ya tuvo este turno la semana pasada";
                    notificaciones[3] = "warning";
                    TempData["Notificaciones"] = notificaciones;
                }

                if (mismoDia.Any(t => t.Empl_Id == item.Empl_Id))
                {
                    string[] notificaciones = new string[4];
                    notificaciones[0] = "tim-icons icon-bell-55";
                    notificaciones[1] = "Advertencia";
                    notificaciones[2] = "Este empleado ya tiene un turno para este dia";
                    notificaciones[3] = "warning";
                    TempData["Notificaciones"] = notificaciones;
                }

                if (turnoNocturno.Any(t => t.Empl_Id == item.Empl_Id))
                {
                    string[] notificaciones = new string[4];
                    notificaciones[0] = "tim-icons icon-bell-55";
                    notificaciones[1] = "Advertencia";
                    notificaciones[2] = "No puede tener este turno 2 dias seguidos";
                    notificaciones[3] = "warning";
                    TempData["Notificaciones"] = notificaciones;
                }

                if (false)
                {
                    //listo para insertar
                    item.TuEm_Creacion = 1;
                    item.TuEm_FechaCreacion = DateTime.Now;
                    var list = await _turnosPorEmpleadoService.CrearTurnoEmpleado(item);
                    string[] notificaciones = new string[4];
                    notificaciones[0] = "tim-icons icon-alert-circle-exc";
                    notificaciones[1] = "Agregado";
                    notificaciones[2] = "Se agregaron los datos con exito";
                    notificaciones[3] = "info";
                    TempData["Notificaciones"] = notificaciones;
                }

                return RedirectToAction("Index", "TurnosPorEmpleado");
            }
            catch (Exception ex)
            {
                return RedirectToAction("Index", "TurnosPorEmpleado");
            }
        }
    }
}
