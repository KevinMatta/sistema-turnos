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
    public class CargoController : Controller
    {
        public readonly CargoService _cargoService;
        public RolService _rolService;
        public CargoController(CargoService cargoService, RolService rolService)
        {
            _rolService = rolService;
            _cargoService = cargoService;
        }

        [HttpGet("Cargo/Listado")]
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
                    //int valor = 0;
                    //if (rol != "")
                    //{
                    //    var url = await _rolService.ValidarUrl(7, int.Parse(rol));
                    //    var validarurl = url.Data as IEnumerable<RolViewModel>;
                    //    foreach (var item in validarurl)
                    //    {
                    //        int? rol_id = item.Rol_Id;
                    //        valor = 1;
                    //    }
                    //}

                    //if (valor == 1 || HttpContext.Session.GetString("IsAdmin") == "IsAdmin") 
                    //{

                        var model = new List<CargoViewModel>();
                        var list = await _cargoService.ObtenerCargoList();
                        return View(list.Data);
                    //}

                    //else
                    //{
                    //    return RedirectToAction("Index", "Home");
                    //}

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
        public async Task<IActionResult> Create(CargoViewModel item)
        {

            try
            {
                string cargo = item.Carg_Descripcion;
                item.Carg_Creacion = int.Parse(HttpContext.Session.GetString("Usua_Id"));
                item.Carg_FechaCreacion = DateTime.Now;
                var list = await _cargoService.CrearCargo(item);
                string[] notificaciones = new string[4];
                notificaciones[0] = "tim-icons icon-alert-circle-exc";
                notificaciones[1] = "Agregado";
                notificaciones[2] = "Se agregaron los datos con exito";
                notificaciones[3] = "info";
                TempData["Notificaciones"] = notificaciones;

                return RedirectToAction("Index", "Cargo");

                //return View(new List<DepartamentoViewModel> { (DepartamentoViewModel)list.Data } );
            }
            catch (Exception ex)
            {
                return View(item);
            }
        }

        [HttpGet("Cargo/Edit{id}")]
        public async Task<IActionResult> Edit(int id)
        {
            try
            {
                var model = await _cargoService.ObtenerCargo(id);
                return Json(model.Data);
            }
            catch (Exception ex)
            {
                return RedirectToAction("Index", "Cargo");
            }
        }

        [HttpPost("Cargo/Edit")]
        public async Task<IActionResult> Edit(CargoViewModel item, int Carg_Id, string Carg_Descripcion)
        {

            try
            {
                item.Carg_Id = Carg_Id;
                item.Carg_Descripcion = Carg_Descripcion;
                item.Carg_Modificacion = int.Parse(HttpContext.Session.GetString("Usua_Id"));
                //item.Ciud_FechaModificacion = DateTime.Now;
                var result = await _cargoService.EditarCargo(item);
                if (result.Success)
                {
                    string[] notificaciones = new string[4];
                    notificaciones[0] = "tim-icons icon-alert-circle-exc";
                    notificaciones[1] = "Exito";
                    notificaciones[2] = "Se edito el registro con exito";
                    notificaciones[3] = "info";
                    TempData["Notificaciones"] = notificaciones;
                    return RedirectToAction("Index", "Cargo");
                }
                else
                {
                    return RedirectToAction("Index", "Cargo");
                }
            }
            catch (Exception ex)
            {
                return RedirectToAction("Index", "Cargo");
                throw;
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int Carg_Id, int Carg_Modificacion,DateTime Carg_FechaModificacion)
        { 
            try
            {
                Carg_Modificacion = int.Parse(HttpContext.Session.GetString("Usua_Id"));
                Carg_FechaModificacion = DateTime.Now;

                var list = await _cargoService.EliminarCargo(Carg_Id, Carg_Modificacion, Carg_FechaModificacion);
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
                return RedirectToAction("Index", "Cargo");
            }
            catch (Exception ex)
            {
                return RedirectToAction("Index", "Cargo");
            }
        }

        [ResponseCache(Location = ResponseCacheLocation.None, NoStore = true)]
        public async Task<IActionResult> Details(int Carg_Id)
        {
            string rol = HttpContext.Session.GetString("roles");

            if (rol == "0")
            {
                return RedirectToAction("Login", "Home");
            }
            else
            {
                var response = await _cargoService.DetallesCargo(Carg_Id);

                if (response.Success)
                {

                    return View(response.Data);

                }

                else
                {

                    return RedirectToAction("Index", "Cargo");
                }
            }
        }
    }
}
