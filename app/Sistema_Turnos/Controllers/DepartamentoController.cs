using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Sistema_Turnos.Models;
using Sistema_Turnos.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_Turnos.Controllers
{
    public class DepartamentoController : Controller
    {
        public DepartamentoService _departamentoServicios;
        public RolService _rolService;
        public DepartamentoController(DepartamentoService departamentoServicios, RolService rolService)
        {
            _departamentoServicios = departamentoServicios;
            _rolService = rolService;
        }
        // GET: DepartamentosController

        [HttpGet("Departamento/Listado")]
        [ResponseCache(Location = ResponseCacheLocation.None, NoStore = true)]
        public async Task<IActionResult> Index()
        {
            try
            {
                string rol = HttpContext.Session.GetString("roles");

                if(rol == "0")
                {
                    return RedirectToAction("Login", "Home");
                }

                else 
                {
                    int valor = 0;
                    var url = await _rolService.ValidarUrl(2, int.Parse(rol));
                    var validarurl = url.Data as IEnumerable<RolViewModel>;

                    foreach (var item in validarurl)
                    {
                        int? rol_id = item.Rol_Id;
                        valor = 1;
                    }

                    if(valor == 1)
                    {
                        var model = new List<DepartamentoViewModel>();
                        var list = await _departamentoServicios.ObtenerDepartamentoList();
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

        public ActionResult Create()
        {
            return View();
        }

        // POST: DepartamentosController/CreateDepartamentos
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(DepartamentoViewModel item)
        {
            try
            {
                int codigo = 0;
                int depto = 0;
                string codigo_depa = item.Esta_Id;
                string Esta_Descripcion = item.Esta_Descripcion;

                var response = await _departamentoServicios.DetallesDepartamento(codigo_depa);
                var listtt = await _departamentoServicios.ObtenerEstadooo(Esta_Descripcion);

                var depaname = response.Data as IEnumerable<DepartamentoViewModel>;
                var depaid = response.Data as IEnumerable<DepartamentoViewModel>;

                if (depaid.ToList().Count > 0 && depaname.ToList().Count > 0)
                {
                    string[] notificaciones = new string[4];
                    notificaciones[0] = "tim-icons icon-alert-circle-exc";
                    notificaciones[1] = "Error";
                    notificaciones[2] = "Ya existe un departamento con ese codigo y ese nombre";
                    notificaciones[3] = "danger";
                    TempData["Notificaciones"] = notificaciones;
                    return RedirectToAction("Index");
                }

                if (depaname.ToList().Count > 0)
                {
                    string[] notificaciones = new string[4];
                    notificaciones[0] = "tim-icons icon-alert-circle-exc";
                    notificaciones[1] = "Error";
                    notificaciones[2] = "Ya existe un departamento con ese nombre";
                    notificaciones[3] = "danger";
                    TempData["Notificaciones"] = notificaciones;
                    return RedirectToAction("Index");
                }

                if(depaid.ToList().Count > 0)
                {
                    string[] notificaciones = new string[4];
                    notificaciones[0] = "tim-icons icon-alert-circle-exc";
                    notificaciones[1] = "Error";
                    notificaciones[2] = "Ya existe un departamento con ese codigo";
                    notificaciones[3] = "danger";
                    TempData["Notificaciones"] = notificaciones;
                    return RedirectToAction("Index");
                }

                else 
                {
                    item.Esta_Creacion = 1;
                    item.Esta_FechaCreacion = DateTime.Now;
                    var list = await _departamentoServicios.CrearDepartamento(item);
                    string[] notificaciones = new string[4];
                    notificaciones[0] = "tim-icons icon-alert-circle-exc";
                    notificaciones[1] = "Agregado";
                    notificaciones[2] = "Se agregaron los datos con exito";
                    notificaciones[3] = "info";
                    TempData["Notificaciones"] = notificaciones;

                    return RedirectToAction("Index", "Departamento");
                }

                //return View(new List<DepartamentoViewModel> { (DepartamentoViewModel)list.Data } );
            }
            catch (Exception ex)
            {
                return View(item);
            }
        }

        [HttpGet("Departamento/Edit{id}")]
        public async Task<IActionResult> Edit(string id)
        {
            try
            {
                var model = await _departamentoServicios.ObtenerDepartamento(id);
                return Json(model.Data);
            }
            catch (Exception ex)
            {
                return RedirectToAction("Index");
            }
        }

        [HttpPost("Departamento/Edit")]
        public async Task<IActionResult> Edit(DepartamentoViewModel item, string Descripcion, string id)
        {
            try
            {
                item.Esta_Id = id;
                item.Esta_Descripcion = Descripcion;
                item.Esta_Modificacion = 1;
                item.Esta_FechaModificacion = DateTime.Now;
                var result = await _departamentoServicios.EditarDepartamento(item);
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
        public async Task<IActionResult> Delete([FromForm] string Esta_Id)
        {
            try
            {
                var list =  await _departamentoServicios.EliminarDepartamento(Esta_Id);
                var hola = list.Message;
                if (hola == "Error al realizar la operacion.") 
                {
                    string[] notificaciones = new string[4];
                    notificaciones[0] = "tim-icons icon-alert-circle-exc";
                    notificaciones[1] = "Error";
                    notificaciones[2] = "Ocurrio un error al eliminar el departamento";
                    notificaciones[3] = "danger";
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


        public async Task<IActionResult> Details(string Esta_Id)
        {
            var response = await _departamentoServicios.DetallesDepartamento(Esta_Id);
            if (response.Success)
            {

                var data = response.Data as IEnumerable<DepartamentoViewModel>;

            foreach (var item in data)
            {
                    var descripcion = item.Esta_Descripcion;
                    var fecha = item.Esta_FechaCreacion;
                    var id = item.Esta_Id;
            }

            return View(response.Data); 

            }

            else
            {

                return RedirectToAction("Index", "Departamento");
            }
        }

    }
}


