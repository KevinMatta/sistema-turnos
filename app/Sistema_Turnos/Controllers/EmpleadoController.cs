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
    public class EmpleadoController : Controller
    {

        public readonly EmpleadoService _empleadoService;
        public readonly PersonaService _personaService;
        public readonly UsuarioService _usuarioService;
        public readonly CargoService _cargoService;
        public readonly HospitalService _hospitalService;
        public RolService _rolService;
        public EmpleadoController(EmpleadoService empleadoService, RolService rolService, PersonaService personaService, UsuarioService usuarioService, CargoService cargoService, HospitalService hospitalService)
        {
            _rolService = rolService;
            _empleadoService = empleadoService;
            _personaService = personaService;
            _usuarioService = usuarioService;
            _cargoService = cargoService;
            _hospitalService = hospitalService;

        }

        [HttpGet("Empleado/Listado")]
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
                    //    var url = await _rolService.ValidarUrl(10, int.Parse(rol));
                    //    var validarurl = url.Data as IEnumerable<RolViewModel>;
                    //    foreach (var item in validarurl)
                    //    {
                    //        int? rol_id = item.Rol_Id;
                    //        valor = 1;
                    //    }
                    //}

                    //if (valor == 1 || HttpContext.Session.GetString("IsAdmin") == "IsAdmin")
                    //{

                        var listapersona = await _personaService.PersonasList();
                        var person = listapersona.Data as IEnumerable<PersonaViewModel>;
                        var pers = person.ToList().Select(x => new SelectListItem { Text = (x.Pers_PrimerNombre + ' ' + x.Pers_PrimerApellido), Value = x.Pers_Identidad }).ToList();
                        pers.Insert(0, new SelectListItem { Text = "Seleccione", Value = "1" });
                        ViewBag.persona = pers;

                        var listausuario = await _usuarioService.ObtenerUsuarioList();
                        var usuar = listausuario.Data as IEnumerable<UsuarioViewModel>;
                        var usua = usuar.ToList().Select(x => new SelectListItem { Text = x.Usua_Usuario, Value = x.Usua_Id.ToString() }).ToList();
                        usua.Insert(0, new SelectListItem { Text = "Seleccione", Value = "1" });
                        ViewBag.usuario = usua;

                        var listcargos = await _cargoService.ObtenerCargoList();
                        var cargo = listcargos.Data as IEnumerable<CargoViewModel>;
                        var carg = cargo.ToList().Select(x => new SelectListItem { Text = x.Carg_Descripcion, Value = x.Carg_Id.ToString() }).ToList();
                        carg.Insert(0, new SelectListItem { Text = "Seleccione", Value = "1" });
                        ViewBag.cargo = carg;

                        var listhospitales = await _hospitalService.ObtenerHospitalList();
                        var hospital = listhospitales.Data as IEnumerable<HospitalViewModel>;
                        var hospi = hospital.ToList().Select(x => new SelectListItem { Text = x.Hosp_Descripcion, Value = x.Hosp_Id.ToString() }).ToList();
                        hospi.Insert(0, new SelectListItem { Text = "Seleccione", Value = "1" });
                        ViewBag.hospital = hospi;

                        var model = new List<EmpleadoViewModel>();
                        var list = await _empleadoService.EmpleadosList();
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
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create()
        {

            try
            {
                return View();

            }
            catch (Exception ex)
            {
                return View();
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(EmpleadoViewModel item)
        {

            try
            {
                item.Empl_Creacion = int.Parse(HttpContext.Session.GetString("Usua_Id"));
                item.Empl_FechaCreacion = DateTime.Now;
                var list = await _empleadoService.CrearEmpleado(item);
                string[] notificaciones = new string[4];
                notificaciones[0] = "tim-icons icon-alert-circle-exc";
                notificaciones[1] = "Agregado";
                notificaciones[2] = "Se agregaron los datos con exito";
                notificaciones[3] = "info";
                TempData["Notificaciones"] = notificaciones;

                return RedirectToAction("Index", "Empleado");

                //return View(new List<DepartamentoViewModel> { (DepartamentoViewModel)list.Data } );
            }
            catch (Exception ex)
            {
                return View(item);
            }
        }

        [HttpGet("Empleado/Edit{id}")]
        public async Task<IActionResult> Edit(int id)
        {
            try
            {
                var listapersona = await _personaService.PersonasList();
                var person = listapersona.Data as IEnumerable<PersonaViewModel>;
                var pers = person.ToList().Select(x => new SelectListItem { Text = (x.Pers_PrimerNombre + ' ' + x.Pers_PrimerApellido), Value = x.Pers_Identidad }).ToList();
                pers.Insert(0, new SelectListItem { Text = "Seleccione", Value = "1" });
                ViewBag.persona = pers;

                var listausuario = await _usuarioService.ObtenerUsuarioList();
                var usuar = listausuario.Data as IEnumerable<UsuarioViewModel>;
                var usua = usuar.ToList().Select(x => new SelectListItem { Text = x.Usua_Usuario, Value = x.Usua_Id.ToString() }).ToList();
                usua.Insert(0, new SelectListItem { Text = "Seleccione", Value = "1" });
                ViewBag.usuario = usua;

                var listcargos = await _cargoService.ObtenerCargoList();
                var cargo = listcargos.Data as IEnumerable<CargoViewModel>;
                var carg = cargo.ToList().Select(x => new SelectListItem { Text = x.Carg_Descripcion, Value = x.Carg_Id.ToString() }).ToList();
                carg.Insert(0, new SelectListItem { Text = "Seleccione", Value = "1" });
                ViewBag.cargo = carg;

                var listhospitales = await _hospitalService.ObtenerHospitalList();
                var hospital = listhospitales.Data as IEnumerable<HospitalViewModel>;
                var hospi = hospital.ToList().Select(x => new SelectListItem { Text = x.Hosp_Descripcion, Value = x.Hosp_Id.ToString() }).ToList();
                hospi.Insert(0, new SelectListItem { Text = "Seleccione", Value = "1" });
                ViewBag.hospital = hospi;

                var model = await _empleadoService.ObtenerEmpleado(id);
                return Json(model.Data);
            }
            catch (Exception ex)
            {
                return RedirectToAction("Index", "Empleado");
            }
        }

        [HttpPost("Empleado/Edit")]
        public async Task<IActionResult> Edit(EmpleadoViewModel item)
        {

            try
            {
                item.Empl_Modificacion = int.Parse(HttpContext.Session.GetString("Usua_Id"));
                item.Empl_FechaModificacion = DateTime.Now;
                var result = await _empleadoService.EditarEmpleado(item);
                if (result.Success)
                {
                    string[] notificaciones = new string[4];
                    notificaciones[0] = "tim-icons icon-alert-circle-exc";
                    notificaciones[1] = "Exito";
                    notificaciones[2] = "Se edito el registro con exito";
                    notificaciones[3] = "info";
                    TempData["Notificaciones"] = notificaciones;
                    return RedirectToAction("Index", "Empleado");
                }
                else
                {
                    return RedirectToAction("Index", "Empleado");
                }
            }
            catch (Exception ex)
            {
                return RedirectToAction("Index", "Empleado");
                throw;
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int tunos, int modificacion, DateTime fecha)
        {
            try
            {
                modificacion = int.Parse(HttpContext.Session.GetString("Usua_Id"));
                fecha = DateTime.Now;

                var list = await _empleadoService.EliminarEmpleado(tunos, modificacion, fecha);
                var hola = list.Message;
                if (hola == "Error al realizar la operacion.")
                {
                    string[] notificaciones = new string[4];
                    notificaciones[0] = "tim-icons icon-bell-55";
                    notificaciones[1] = "Error";
                    notificaciones[2] = "Ocurrio un error al eliminar el empleado";
                    notificaciones[3] = "warning";
                    TempData["Notificaciones"] = notificaciones;
                }
                else
                {
                    string[] notificaciones = new string[4];
                    notificaciones[0] = "tim-icons icon-alert-circle-exc";
                    notificaciones[1] = "Exito";
                    notificaciones[2] = "Se elimino el empleado con exito";
                    notificaciones[3] = "info";
                    TempData["Notificaciones"] = notificaciones;
                }
                return RedirectToAction("Index", "Empleado");
            }
            catch (Exception ex)
            {
                return RedirectToAction("Index", "Empleado");
            }
        }

        [ResponseCache(Location = ResponseCacheLocation.None, NoStore = true)]
        public async Task<IActionResult> Details(int Empl_Id)
        {
            string rol = HttpContext.Session.GetString("roles");

            if (rol == "0")
            {
                return RedirectToAction("Login", "Home");
            }
            else
            {
                var response = await _empleadoService.DetallesEmpelado(Empl_Id);

                if (response.Success)
                {

                    return View(response.Data);

                }

                else
                {

                    return RedirectToAction("Index", "Empleado");
                }
            }
        }

    }
}
