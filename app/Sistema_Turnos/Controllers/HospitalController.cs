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
    public class HospitalController : Controller
    {
        public readonly HospitalService _hospitalService;
        public RolService _rolService;
        public HospitalController(HospitalService hospitalService, RolService rolService)
        {
            _rolService = rolService;
            _hospitalService = hospitalService;
        }

        [HttpGet("Hospital/Listado")]
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
                        var list = await _hospitalService.ObtenerHospitalList();
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
        public async Task<IActionResult> Create(HospitalViewModel item)
        {

            try
            {
                item.Hosp_Creacion = int.Parse(HttpContext.Session.GetString("Usua_Id"));
                item.Hosp_FechaCreacion = DateTime.Now;
                var list = await _hospitalService.CrearHospital(item);
                string[] notificaciones = new string[4];
                notificaciones[0] = "tim-icons icon-alert-circle-exc";
                notificaciones[1] = "Agregado";
                notificaciones[2] = "Se agregaron los datos con exito";
                notificaciones[3] = "info";
                TempData["Notificaciones"] = notificaciones;

                return RedirectToAction("Index", "Hospital");

                //return View(new List<DepartamentoViewModel> { (DepartamentoViewModel)list.Data } );
            }
            catch (Exception ex)
            {
                return View(item);
            }
        }

        [HttpGet("Hospital/Edit{id}")]
        public async Task<IActionResult> Edit(int id)
        {
            try
            {
                var model = await _hospitalService.ObtenerHospital(id);
                return Json(model.Data);
            }
            catch (Exception ex)
            {
                return RedirectToAction("Index", "Hospital");
            }
        }

        [HttpPost("Cargo/Edit")]
        public async Task<IActionResult> Edit(HospitalViewModel item, int Hosp_Id, string Hosp_Descripcion, string Hosp_Direccion, string Ciud_Id)
        {

            try
            {
                item.Hosp_Id = Hosp_Id;
                item.Hosp_Descripcion = Hosp_Descripcion;
                item.Hosp_Direccion = Hosp_Direccion;
                item.Ciud_Id = Ciud_Id;
                item.Hosp_Modificacion = int.Parse(HttpContext.Session.GetString("Usua_Id"));
                //item.Ciud_FechaModificacion = DateTime.Now;
                var result = await _hospitalService.EditarHospital(item);
                if (result.Success)
                {
                    string[] notificaciones = new string[4];
                    notificaciones[0] = "tim-icons icon-alert-circle-exc";
                    notificaciones[1] = "Exito";
                    notificaciones[2] = "Se edito el registro con exito";
                    notificaciones[3] = "info";
                    TempData["Notificaciones"] = notificaciones;
                    return RedirectToAction("Index", "Hospital");
                }
                else
                {
                    return RedirectToAction("Index", "Hospital");
                }
            }
            catch (Exception ex)
            {
                return RedirectToAction("Index", "Hospital");
                throw;
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int Hosp_Id, int Hosp_Modificacion, DateTime Hosp_FechaModificacion)
        {
            try
            {
                Hosp_Modificacion = int.Parse(HttpContext.Session.GetString("Usua_Id"));
                Hosp_FechaModificacion = DateTime.Now;

                var list = await _hospitalService.EliminarHospital(Hosp_Id, Hosp_Modificacion, Hosp_FechaModificacion);
                var hola = list.Message;
                if (hola == "Error al realizar la operacion.")
                {
                    string[] notificaciones = new string[4];
                    notificaciones[0] = "tim-icons icon-bell-55";
                    notificaciones[1] = "Error";
                    notificaciones[2] = "Ocurrio un error al eliminar el cargo";
                    notificaciones[3] = "warning";
                    TempData["Notificaciones"] = notificaciones;
                }
                else
                {
                    string[] notificaciones = new string[4];
                    notificaciones[0] = "tim-icons icon-alert-circle-exc";
                    notificaciones[1] = "Exito";
                    notificaciones[2] = "Se elimino el cargo con exito";
                    notificaciones[3] = "info";
                    TempData["Notificaciones"] = notificaciones;
                }
                return RedirectToAction("Index", "Hospital");
            }
            catch (Exception ex)
            {
                return RedirectToAction("Index", "Hospital");
            }
        }

        [ResponseCache(Location = ResponseCacheLocation.None, NoStore = true)]
        public async Task<IActionResult> Details(int id)
        {
            string rol = HttpContext.Session.GetString("roles");

            if (rol == "0")
            {
                return RedirectToAction("Login", "Home");
            }
            else
            {
                var response = await _hospitalService.DetallesHospital(id);

                if (response.Success)
                {

                    return View(response.Data);

                }

                else
                {

                    return RedirectToAction("Index", "Hospital");
                }
            }
        }

    }
}
