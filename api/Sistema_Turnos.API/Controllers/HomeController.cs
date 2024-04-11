using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sistema_Turnos.BusinessLogic.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sistema_Turnos.API.Controllers
{
    [Route("/API/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private readonly AccesoServices _accesoServices;
        private readonly IMapper _imapper;

        public HomeController(AccesoServices accesoServices, IMapper mapper)
        {
            _accesoServices = accesoServices;
            _imapper = mapper;
        }

        [HttpGet("LoginHome")]
        public IActionResult Login (string Usuario, string Contra)
        {
            var usuario = _accesoServices.ValidarUsuario(Usuario);
            var clave = _accesoServices.ValidarClave(Contra);
            var list = _accesoServices.Login(Usuario, Contra);

            return Ok(list);
        }

        [HttpPost("ValidarUsuarioHome")]
        public IActionResult ValidarUsuario(string Usuario)
        {
            var usuario = _accesoServices.ValidarUsuario(Usuario);
            return Ok(usuario);
        }
        [HttpPost("ValidarClaveHome")]
        public IActionResult ValidarClave( string Contra)
        {
            var clave = _accesoServices.ValidarClave(Contra);
            return Ok(clave);
        }

    }
}
