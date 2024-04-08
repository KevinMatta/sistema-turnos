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

namespace FrontendCNE.Controllers
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
                TempData["Bienvenida"] = "Bienvenido a la Pantalla de Departamentos";
                TempData["PantallaDepartamentos"] = true;
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
                item.Esta_Creacion = 1;
                item.Esta_FechaCreacion = DateTime.Now;
                var list = await _departamentoServicios.CrearDepartamento(item);
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
                var list = await _departamentoServicios.EliminarDepartamento(Esta_Id);
                return RedirectToAction("Index");
                //return View(new List<DepartamentoViewModel> { (DepartamentoViewModel)list.Data } );
            }
            catch (Exception ex)
            {
                return RedirectToAction("Index");
            }
        }

        // GET: DepartamentosController/DetailsDepartamentosz
        public async Task<IActionResult> Details(string Esta_Id)
        {
            try
            {
                var list = await _departamentoServicios.DetallesDepartamento(Esta_Id);
                return View(list.Data);
            }
            catch (Exception ex)
            {
                return RedirectToAction("Index", "Home");
            }
        }

    }
}


