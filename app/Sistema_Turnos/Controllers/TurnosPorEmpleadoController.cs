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
    public class TurnosPorEmpleadoController : Controller
    {
        public TurnosPorEmpleadoService _turnosPorEmpleadoService;
        public RolService _rolService;
        public TurnosPorEmpleadoController(TurnosPorEmpleadoService turnosPorEmpleadoService, RolService rolService)
        {
            _turnosPorEmpleadoService = turnosPorEmpleadoService;
            _rolService = rolService;
        }
        [HttpGet("ListTurnosEmpleados")]
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

                    if(valor == 1 || HttpContext.Session.GetString("IsAdmin") == "IsAdmin")
                    {
                        var model = new List<TurnosPorEmpleadoViewModel>();
                        var list = await _turnosPorEmpleadoService.TurnosPorEmpleadoList();
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
    }
}
