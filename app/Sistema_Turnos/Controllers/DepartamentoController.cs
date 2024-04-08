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
        public DepartamentoController(DepartamentoService departamentoServicios)
        {
            _departamentoServicios = departamentoServicios;
        }
        // GET: DepartamentosController
        public async Task<IActionResult> Index()
        {
            try
            {
                var model = new List<DepartamentoViewModel>();
                var list = await _departamentoServicios.ObtenerDepartamentoList();
                return View(list.Data);
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
                var list = await _departamentoServicios.CrearDepartamento(item);
                item.Esta_Creacion = 1;
                item.Esta_FechaCreacion = DateTime.Now;
                string[] notificaciones = new string[4];
                notificaciones[0] = "tim-icons icon-alert-circle-exc";
                notificaciones[1] = "Agregado";
                notificaciones[2] = "Se agregaron los datos con exito";
                notificaciones[3] = "info";
                TempData["Notificaciones"] = notificaciones;

                return RedirectToAction("Index");
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


