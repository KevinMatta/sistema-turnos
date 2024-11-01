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
    public class UsuarioController : Controller
    {
        public readonly UsuarioService _usuarioService;
        public RolService _rolService;
        public UsuarioController(UsuarioService usuarioService, RolService rolService)
        {
            _usuarioService = usuarioService;
            _rolService = rolService;
        }

        [HttpGet("Usuario/Listado")]
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
                    //if(rol != "") 
                    //{
                    //    var url = await _rolService.ValidarUrl(4, int.Parse(rol));
                    //    var validarurl = url.Data as IEnumerable<RolViewModel>;
                    //    foreach (var item in validarurl)
                    //    {
                    //        int? rol_id = item.Rol_Id;
                    //        valor = 1;
                    //    }
                    //}

                    //if (valor == 1 || HttpContext.Session.GetString("IsAdmin") == "IsAdmin")
                    
                    //    var listarol = await _rolService.ObtenerRolList();
                    //    var roles = listarol.Data as IEnumerable<RolViewModel>;
                    //    var role = roles.ToList().Select(x => new SelectListItem { Text = x.Rol_Descripcion, Value = x.Rol_Id.ToString() }).ToList();
                    //    role.Insert(0, new SelectListItem { Text = "Seleccione", Value = "1" });
                    //    ViewBag.Rol = role;

                        var model = new List<UsuarioViewModel>();
                        var list = await _usuarioService.ObtenerUsuarioList();
                        return View(list.Data);
                    

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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(UsuarioViewModel item, bool txtadmin)
        {
            try
            {
                item.Usua_IsAdmin = txtadmin;
                item.Usua_Creacion = int.Parse(HttpContext.Session.GetString("Usua_Id"));
                item.Usua_FechaCreacion = DateTime.Now;

                if (item.Usua_IsAdmin == true)
                {
                    item.Rol_Id = null;
                }

                if (item.Rol_Id != null)
                {
                    item.Usua_IsAdmin = false;
                }

                var list = await _usuarioService.CrearUsuario(item);
                string[] notificaciones = new string[4];
                notificaciones[0] = "tim-icons icon-alert-circle-exc";
                notificaciones[1] = "Agregado";
                notificaciones[2] = "Se agregaron los datos con exito";
                notificaciones[3] = "info";
                TempData["Notificaciones"] = notificaciones;

                return RedirectToAction("Index", "Usuario");

                //return View(new List<DepartamentoViewModel> { (DepartamentoViewModel)list.Data } );
            }
            catch (Exception ex)
            {
                return View(item);
            }
        }

        [HttpGet("Usuario/Edit{id}")]
        public async Task<IActionResult> Edit(int id)
        {
            try
            {
                var model = await _usuarioService.ObtenerUsuario(id);
                return Json(model.Data);
            }
            catch (Exception ex)
            {
                return RedirectToAction("Index", "Usuario");
            }
        }

        [HttpPost("Usuario/Edit")]
        public async Task<IActionResult> Edit(UsuarioViewModel item, int iddd, bool txtadmin)
        {

            try
            {
                item.Usua_Modificacion = int.Parse(HttpContext.Session.GetString("Usua_Id"));
                item.Usua_Id = iddd;
                item.Usua_IsAdmin = txtadmin;

                if (item.Usua_IsAdmin == true)
                {
                    item.Rol_Id = null;
                }

                if (item.Rol_Id != null)
                {
                    item.Usua_IsAdmin = false;
                }

                //item.Ciud_FechaModificacion = DateTime.Now;
                var result = await _usuarioService.EditarUsuario(item);
                txtadmin = false;
                item.Rol_Id = null;
                if (result.Success)
                {
                    string[] notificaciones = new string[4];
                    notificaciones[0] = "tim-icons icon-alert-circle-exc";
                    notificaciones[1] = "Exito";
                    notificaciones[2] = "Se edito el registro con exito";
                    notificaciones[3] = "info";
                    TempData["Notificaciones"] = notificaciones;
                    return RedirectToAction("Index", "Usuario");
                }
                else
                {
                    return RedirectToAction("Index", "Usuario");
                }
            }
            catch (Exception ex)
            {
                return RedirectToAction("Index", "Usuario");
                throw;
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int Usua_Id, int Usua_Modificacion, DateTime Usua_FechaModificacion)
        {
            try
            {
                Usua_Modificacion = int.Parse(HttpContext.Session.GetString("Usua_Id"));
                Usua_FechaModificacion = DateTime.Now;

                var list = await _usuarioService.EliminarUsuario(Usua_Id, Usua_Modificacion, Usua_FechaModificacion);
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
                    notificaciones[2] = "Se elimino el usuario con exito";
                    notificaciones[3] = "info";
                    TempData["Notificaciones"] = notificaciones;
                }
                return RedirectToAction("Index", "Usuario");
            }
            catch (Exception ex)
            {
                return RedirectToAction("Index", "Usuario");
            }
        }

        [ResponseCache(Location = ResponseCacheLocation.None, NoStore = true)]
        public async Task<IActionResult> Details(int Usua_Id)
        {
            string rol = HttpContext.Session.GetString("roles");

            if (rol == "0")
            {
                return RedirectToAction("Login", "Home");
            }
            else
            {
                var response = await _usuarioService.DetallesUsuario(Usua_Id);

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
        public async Task<IActionResult> Restablecer(int Usua_Id, string Usua_Clave, int Usua_Modificacion, DateTime Usua_FechaModificacion)
        {
            try
            {
                Usua_Modificacion = int.Parse(HttpContext.Session.GetString("Usua_Id"));
                Usua_FechaModificacion = DateTime.Now;

                var list = await _usuarioService.Restablecer(Usua_Id, Usua_Clave, Usua_Modificacion, Usua_FechaModificacion);
                var hola = list.Message;
                if (hola == "Error al realizar la operacion.")
                {
                    string[] notificaciones = new string[4];
                    notificaciones[0] = "tim-icons icon-bell-55";
                    notificaciones[1] = "Error";
                    notificaciones[2] = "Ocurrio un error al actualizar la clave";
                    notificaciones[3] = "warning";
                    TempData["Notificaciones"] = notificaciones;
                }
                else
                {
                    string[] notificaciones = new string[4];
                    notificaciones[0] = "tim-icons icon-alert-circle-exc";
                    notificaciones[1] = "Exito";
                    notificaciones[2] = "Se actualizo la clave con exito";
                    notificaciones[3] = "info";
                    TempData["Notificaciones"] = notificaciones;
                }
                return RedirectToAction("Index", "Usuario");
            }
            catch (Exception ex)
            {
                return RedirectToAction("Index", "Usuario");
            }
        }

    }
}
