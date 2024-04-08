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

                return View(list.Data);
            }
            catch (Exception ex)
            {
                return RedirectToAction("Index", "Home");
            }
        }
    }
}
