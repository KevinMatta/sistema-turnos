using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Sistema_Turnos.BusinessLogic.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Sistema_Turnos.API.Clases;
using Sistema_Turnos.Entities.Entities;
using Sistema_Turnos.Common.Models;
using Microsoft.AspNetCore.Http;

namespace Sistema_Turnos.API.Controllers
{
    [ApiController]
    [Route("/API/[controller]")]
    public class RolController : Controller
    {

        private readonly AccesoServices _accesoServices;
        private readonly IMapper _mapper;

        public RolController(AccesoServices accesoServices, IMapper mapper)
        {
            _accesoServices = accesoServices;
            _mapper = mapper;
        }

        [HttpGet("ListadoRoles")]
        public IActionResult Index()
        {
            var list = _accesoServices.ListRol();
            return Ok(list);
        }

        [HttpGet("ValidarUrl")]
        public IActionResult ValidarUrl(int Pant_Id, int Rol_Id)
        {
            var list = _accesoServices.ValidarUrl(Pant_Id, Rol_Id);
            return Ok(list);
        }

        [HttpGet("CreatePantalla")]
        public IActionResult Create()
        {
            var list = _accesoServices.ListPantalla();
            return Ok(list);
        }

        [HttpPost("CreatePantalla")]
        public IActionResult Create([FromBody] FormData formData)
        {
            string txtRol = formData.txtRol;

            var r = _accesoServices.ObtenerRol(txtRol);
            var rr = r.Data as IEnumerable<tbRoles>;

            if (rr.ToList().Count > 0)
            {
                return RedirectToAction("https://localhost:44302/CreatePantalla");
            }

            else
            {
                List<int> pantallasSeleccionadas = formData.pantallasSeleccionadas;

                try
                {

                    var modelo = new tbRoles()
                    {
                        Rol_Descripcion = txtRol,
                        Rol_Creacion = 1, // Aquí va la sesión del ID del usuario
                        Rol_FechaCreacion = DateTime.Now
                    };

                    var list = _accesoServices.InsertarRol(modelo);

                    var id = _accesoServices.ObtenerId(modelo.Rol_Creacion, modelo.Rol_FechaCreacion);

                    var rol = id.Data;

                    int rolid = 0;

                    foreach (var item in rol)
                    {
                        rolid = item.Rol_Id;
                    }

                    foreach (var pantalla in pantallasSeleccionadas)
                    {
                        var modelo2 = new tbPantallasPorRoles()
                        {
                            Pant_Id = pantalla,
                            Rol_Id = rolid,
                            PaRo_Creacion = 1,
                            PaRo_FechaCreacion = DateTime.Now
                        };

                        var msj = _accesoServices.InsertarPantallasPorRol(modelo2);
                    }
                    return Ok(list);
                }
                catch
                {

                    return Ok();

                }
            }
        }

        [HttpGet("UpdateRol")]
        public IActionResult Edit(int Rol_id)
        {
            var PantallasPorRol = _accesoServices.ObtenerPantallasPorRol(Rol_id);
            var Pantallas = _accesoServices.ListPantalla();
            var ObtenerRol = _accesoServices.ObtenerRol(Rol_id);

            int rolid = 0;
            string NombreRol = "";

            var Rol = ObtenerRol.Data;

            foreach (var item in Rol)
            {
                rolid = item.Rol_Id;
                NombreRol = item.Rol_Descripcion;
            }


            var pantallasSeleccionadas = PantallasPorRol.Select(p => (int)p.Pant_Id).ToList();

            var panta = Pantallas.Data as IEnumerable<tbPantallas>;

            var pantallasViewModel = _mapper.Map<List<PantallaViewModel>>(panta);

            var rolViewModel = new RolViewModel
            {
                Rol_Id = rolid,
                Rol_Descripcion = NombreRol,
                PantallasID = pantallasSeleccionadas,
                pantallas = (List<PantallaViewModel>)pantallasViewModel,
            };
            return Ok(rolViewModel);
        }

        [HttpPost("UpdateRol")]
        public JsonResult Edit([FromBody] FormData formData)
        {
            if (string.IsNullOrEmpty(formData.txtRol))
            {
                ModelState.AddModelError("txtRol", "El nombre del rol es requerido.");
            }

            var rol = new tbRoles()
            {
                Rol_Id = formData.Rol_Id,
                Rol_Descripcion = formData.txtRol,
                Rol_Modificacion = 1, //debe ir el usuario que lo modifico con una sesion
                Rol_FechaModificacion = DateTime.Now,

            };

            var id = _accesoServices.ObtenerId( (int)rol.Rol_Modificacion, (DateTime)rol.Rol_FechaModificacion);
            var role = id.Data as IEnumerable<tbRoles>;

            var Rol = new tbRoles()
            {
                Rol_Id = formData.Rol_Id,
                Rol_Descripcion = formData.txtRol,
                Rol_Modificacion = 1, //debe ir el usuario que lo modifico con una sesion
                Rol_FechaModificacion = DateTime.Now,

            };

            _accesoServices.ActualizarRol(Rol);
            _accesoServices.EliminarPantallaPorRol(formData.Rol_Id);


            foreach (var pantalla in formData.pantallasSeleccionadas)
            {
                var modelo2 = new tbPantallasPorRoles()
                {
                    Pant_Id = pantalla,
                    Rol_Id = formData.Rol_Id,
                    PaRo_Creacion = 1,
                    PaRo_FechaCreacion = DateTime.Now
                };

                var msj = _accesoServices.InsertarPantallasPorRol(modelo2);
            }

            return Json(1);

        }

        [HttpDelete("DeleteRol")]
        public IActionResult Delete(int Rol_id)
        {
            _accesoServices.EliminarPantallaPorRol(Rol_id);
            var list = _accesoServices.EliminarRol(Rol_id);
            return Ok(list);
        }

    }
}
