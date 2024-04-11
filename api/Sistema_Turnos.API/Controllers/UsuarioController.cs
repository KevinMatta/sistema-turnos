using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Sistema_Turnos.BusinessLogic.Services;
using Sistema_Turnos.Common.Models;
using Sistema_Turnos.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sistema_Turnos.API.Controllers
{
    [ApiController]
    [Route("/API/[controller]")]
    public class UsuarioController : Controller
    {
        private readonly AccesoServices _accesoServices;
        private readonly IMapper _mapper;
        public UsuarioController(AccesoServices accesoServices, IMapper mapper)
        {
            _accesoServices = accesoServices;
            _mapper = mapper;
        }

        [HttpGet("ListadoUsuarios")]
        public IActionResult Index()
        {
            var list = _accesoServices.ListUsuarios();
            return Ok(list);
        }

        [HttpPost("CreateUsuarios")]
        public IActionResult Insert(UsuarioViewModel item)
        {
            var model = _mapper.Map<tbUsuarios>(item);
            var modelo = new tbUsuarios()
            {
                Usua_Usuario = item.Usua_Usuario,
                Usua_Clave = item.Usua_Clave,
                Rol_Id = item.Rol_Id,
                Usua_IsAdmin = item.Usua_IsAdmin,
                Usua_Creacion = item.Usua_Creacion,
                Usua_FechaCreacion= DateTime.Now,
            };
            var list = _accesoServices.InsertarUsuarios(modelo);
            return Ok(list);
        }

        [HttpGet("FillUsuarios/{id}")]

        public IActionResult Llenar(int id)
        {

            var list = _accesoServices.ListUsuar(id);
            return Json(list);
        }

        [HttpPut("UpdateUsuarios")]
        public IActionResult Update(UsuarioViewModel item)
        {
            var model = _mapper.Map<tbUsuarios>(item);
            var modelo = new tbUsuarios()
            {
                Usua_Id = item.Usua_Id,
                Usua_Usuario = item.Usua_Usuario,
                Rol_Id = item.Rol_Id,
                Usua_IsAdmin = item.Usua_IsAdmin,
                Usua_Modificacion = item.Usua_Modificacion,
                Usua_FechaModificacion = DateTime.Now,
            };
            var list = _accesoServices.ActualizarUsuarios(modelo);
            return Ok(list);
        }

        [HttpDelete("DeleteUsuarios")]
        public IActionResult Delete(int id, int usuario, DateTime fecha)
        {
            var list = _accesoServices.EliminarUsuarios(id, usuario, fecha);
            return Ok(list);
        }

        [HttpPost("RestablecerUsuarios")]
        public IActionResult Restablecer(int Usua_Id, string Usua_Clave, int usuario, DateTime fecha)
        {
            var list = _accesoServices.Restablecer(Usua_Id, Usua_Clave, usuario, fecha);
            return Ok(list);
        }

    }
}
