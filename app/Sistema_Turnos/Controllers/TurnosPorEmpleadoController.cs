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
                item.TuEm_Creacion = 1;
                item.TuEm_FechaCreacion = DateTime.Now;
                var list = await _turnosPorEmpleadoService.CrearTurnoEmpleado(item);
                string[] notificaciones = new string[4];
                notificaciones[0] = "tim-icons icon-alert-circle-exc";
                notificaciones[1] = "Agregado";
                notificaciones[2] = "Se agregaron los datos con exito";
                notificaciones[3] = "info";
                TempData["Notificaciones"] = notificaciones;

                return RedirectToAction("Index", "TurnosPorEmpleado");
            }
            catch (Exception ex)
            {
                return RedirectToAction("Index", "TurnosPorEmpleado");
            }
        }
    }
}
