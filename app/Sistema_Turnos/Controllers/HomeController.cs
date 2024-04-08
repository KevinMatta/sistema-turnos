using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Sistema_Turnos.Models;
using Sistema_Turnos.Services;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Sistema_Turnos.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly UsuarioService _usuarioService;

        public HomeController(ILogger<HomeController> logger, UsuarioService usuarioService)
        {
            _logger = logger;
            _usuarioService = usuarioService;
        }

        [AllowAnonymous]
        public async Task<IActionResult> Login(string Usuario, string Contrasenia)
        {
            var list = await _usuarioService.Login(Usuario, Contrasenia);
            var saber = list.Data as IEnumerable<UsuarioViewModel>;
            string usuario = "";

            if(saber.ToList().Count > 0 ) { 

                foreach (var item in saber)
                {
                    usuario = item.Usua_Usuario;
                }

                return RedirectToAction("Index");
            }

            return View();
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
