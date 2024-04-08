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
        public TurnosPorEmpleadoController(TurnosPorEmpleadoService turnosPorEmpleadoService)
        {
            _turnosPorEmpleadoService = turnosPorEmpleadoService;
        }
        [HttpGet("ListTurnosEmpleados")]
        public async Task<IActionResult> Index()
        {
            try
            {
                var model = new List<TurnosPorEmpleadoViewModel>();
                var list = await _turnosPorEmpleadoService.TurnosPorEmpleadoList();
                return View(list.Data);
            }
            catch (Exception ex)
            {
                return RedirectToAction("Index", "Home");
            }
        }
    }
}
