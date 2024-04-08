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
            var list = _accesoServices.Login(Usuario, Contra);
            return Ok(list);
        }
    }
}
