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
    public class MunicipioController : Controller
    {
        public DepartamentoService _departamentoServicios;
        public MunicipioService _municipioService;
        public RolService _rolService;
        public MunicipioController(MunicipioService municipioService, RolService rolService, DepartamentoService departamentoService)
        {
            _municipioService = municipioService;
            _rolService = rolService;
            _departamentoServicios = departamentoService;
        }
        [HttpGet("Municipio/Listado")]
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
                        var url = await _rolService.ValidarUrl(4, int.Parse(rol));
                        var validarurl = url.Data as IEnumerable<RolViewModel>;
                        foreach (var item in validarurl)
                        {
                            int? rol_id = item.Rol_Id;
                            valor = 1;
                        }
                    }

                    if (valor == 1 || HttpContext.Session.GetString("rol") == "Administrador")
                    {
                        var listadepto = await _departamentoServicios.ObtenerDepartamentoList();

                        var depto = listadepto.Data as IEnumerable<DepartamentoViewModel>;

                        var depa = depto.ToList().Select(x => new SelectListItem { Text = x.Esta_Descripcion, Value = x.Esta_Id.ToString() }).ToList();
                        depa.Insert(0, new SelectListItem { Text = "Seleccione", Value = "1" });
                        ViewBag.Departamentos = depa;

                        var model = new List<DepartamentoViewModel>();
                        var list = await _municipioService.ObtenerMunicipioList();
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
        public async Task<IActionResult> Create(MunicipioViewModel item)
        {
            var listadepto = await _departamentoServicios.ObtenerDepartamentoList();
            var depto = listadepto.Data as IEnumerable<DepartamentoViewModel>;
            var depa = depto.ToList().Select(x => new SelectListItem { Text = x.Esta_Descripcion, Value = x.Esta_Id.ToString() }).ToList();
            depa.Insert(0, new SelectListItem { Text = "Seleccione", Value = "1" });
            ViewBag.Departamentos = depa;

            try
            {
                string depasss = item.Esta_Id;
                item.Ciud_Creacion = int.Parse(HttpContext.Session.GetString("Usua_Id"));
                item.Ciud_FechaCreacion = DateTime.Now;
                var list = await _municipioService.CrearMunicipio(item);
                string[] notificaciones = new string[4];
                notificaciones[0] = "tim-icons icon-alert-circle-exc";
                notificaciones[1] = "Agregado";
                notificaciones[2] = "Se agregaron los datos con exito";
                notificaciones[3] = "info";
                TempData["Notificaciones"] = notificaciones;

                return RedirectToAction("Index", "Municipio");

                //return View(new List<DepartamentoViewModel> { (DepartamentoViewModel)list.Data } );
            }
            catch (Exception ex)
            {
                return View(item);
            }
        }

        [HttpGet("Municipio/Edit{id}")]
        public async Task<IActionResult> Edit(string id)
        {
            var listadepto = await _departamentoServicios.ObtenerDepartamentoList();
            var depto = listadepto.Data as IEnumerable<DepartamentoViewModel>;
            var depa = depto.ToList().Select(x => new SelectListItem { Text = x.Esta_Descripcion, Value = x.Esta_Id.ToString() }).ToList();
            depa.Insert(0, new SelectListItem { Text = "Seleccione", Value = "1" });
            ViewBag.Departamentos = depa;
            try
            {
                var model = await _municipioService.ObtenerMunicipio(id);
                return Json(model.Data);
            }
            catch (Exception ex)
            {
                return RedirectToAction("Index");
            }
        }

        [HttpPost("Municipio/Edit")]
        public async Task<IActionResult> Edit(MunicipioViewModel item, string Descripcion, string id, string departamento)
        {
            var listadepto = await _departamentoServicios.ObtenerDepartamentoList();
            var depto = listadepto.Data as IEnumerable<DepartamentoViewModel>;
            var depa = depto.ToList().Select(x => new SelectListItem { Text = x.Esta_Descripcion, Value = x.Esta_Id.ToString() }).ToList();
            depa.Insert(0, new SelectListItem { Text = "Seleccione", Value = "1" });
            ViewBag.Departamentos = depa;

            try
            {
                item.Esta_Id = departamento;
                item.Ciud_Id = id;
                item.Ciud_Descripcion = Descripcion;
                item.Ciud_Modificacion = int.Parse(HttpContext.Session.GetString("Usua_Id"));
                //item.Ciud_FechaModificacion = DateTime.Now;
                var result = await _municipioService.EditarMunicipio(item);
                if (result.Success)
                {
                    string[] notificaciones = new string[4];
                    notificaciones[0] = "tim-icons icon-alert-circle-exc";
                    notificaciones[1] = "Exito";
                    notificaciones[2] = "Se edito el registro con exito";
                    notificaciones[3] = "info";
                    TempData["Notificaciones"] = notificaciones;
                    return RedirectToAction("Index");
                }
                else
                {
                    return View("Index", item);
                }
            }
            catch (Exception ex)
            {
                return View(item);
                throw;
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete([FromForm] string Ciud_Id)
        {
            try
            {
                var list = await _municipioService.EliminarMunicipio(Ciud_Id);
                var hola = list.Message;
                if (hola == "Error al realizar la operacion.")
                {
                    string[] notificaciones = new string[4];
                    notificaciones[0] = "tim-icons icon-bell-55";
                    notificaciones[1] = "Error";
                    notificaciones[2] = "Ocurrio un error al eliminar el departamento";
                    notificaciones[3] = "warning";
                    TempData["Notificaciones"] = notificaciones;
                }
                else
                {
                    string[] notificaciones = new string[4];
                    notificaciones[0] = "tim-icons icon-alert-circle-exc";
                    notificaciones[1] = "Exito";
                    notificaciones[2] = "Se elimino el departamento con exito";
                    notificaciones[3] = "info";
                    TempData["Notificaciones"] = notificaciones;
                }
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return RedirectToAction("Index");
            }
        }

        [ResponseCache(Location = ResponseCacheLocation.None, NoStore = true)]
        public async Task<IActionResult> Details(string Ciud_Id)
        {
            string rol = HttpContext.Session.GetString("roles");

            if (rol == "0")
            {
                return RedirectToAction("Login", "Home");
            }
            else
            {
                var response = await _municipioService.DetallesMunicipio(Ciud_Id);

                if (response.Success)
                {

                    return View(response.Data);

                }

                else
                {

                    return RedirectToAction("Index", "Municipio");
                }
            }
        }

    }
}
