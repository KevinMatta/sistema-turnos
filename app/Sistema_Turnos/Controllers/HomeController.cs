using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Sistema_Turnos.Models;
using Sistema_Turnos.Services;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using System.Text.Json;

namespace Sistema_Turnos.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly UsuarioService _usuarioService;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public HomeController(ILogger<HomeController> logger, UsuarioService usuarioService, IHttpContextAccessor httpContextAccessor)
        {
            _logger = logger;
            _usuarioService = usuarioService;
            _httpContextAccessor = httpContextAccessor;
        }

        [AllowAnonymous]
        [ResponseCache(Location = ResponseCacheLocation.None, NoStore = true)]
        public async Task<IActionResult> Login(string Usuario, string Contrasenia)
        {
            string usuario = "";
            int ? idrol = 0;

            int num = 0;
            HttpContext.Session.SetString("roles", num.ToString());

            if (Usuario != null && Contrasenia != null ) {
                int x = 0;

                int? rol;

                List<string> pantallasPorRol = new List<string>();
                var Claim = new List<Claim>();
                var list = await _usuarioService.Login(Usuario, Contrasenia);
                var saber = list.Data as IEnumerable<UsuarioViewModel>;
                var listsss = saber.ToList();
                if (listsss.Count > 0)
                {
                    var loginlist = listsss.FirstOrDefault();

                    foreach (var item in listsss)
                    {
                        HttpContext.Session.SetString("Usua_Id", item.Usua_Id.ToString());
                        HttpContext.Session.SetString("roles", item.Rol_Id.ToString());
                        HttpContext.Session.SetString("Usuario", item.Usua_Nombre.ToString());
                        pantallasPorRol.Add(item.Pant_Descripcion);
                        if (item.Pant_Descripcion != null)
                        {
                            Claim.Add(new Claim(ClaimTypes.Role, item.Pant_Descripcion));
                        }
                        else
                        {
                            Claim.Add(new Claim(ClaimTypes.Role, "Ninguna Pantalla"));
                        }
                        rol = item.Rol_Id;
                    }

                    if (loginlist.Usua_IsAdmin == true)
                    {
                        pantallasPorRol.Add("Admin");
                        Claim.Add(new Claim(ClaimTypes.Role, "Admin"));
                    }

                    var ClaimsIdentity = new ClaimsIdentity(Claim, CookieAuthenticationDefaults.AuthenticationScheme);


                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(ClaimsIdentity));

                    var pantallasJson = JsonSerializer.Serialize(pantallasPorRol);
                    HttpContext.Session.SetString("Pantallas", pantallasJson);

                   return RedirectToAction("Index");
                }
            }

            return View();
        }

        public async Task<IActionResult> ValidarUsuario(string Usuario)
        {
            var list = await _usuarioService.ValidarUsuario(Usuario);

            return Ok(list.Data);
        }

        [ResponseCache(Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult CerrarSesion()
        {
            int num = 0;
            HttpContext.Session.SetString("roles", num.ToString());
            return View("Login");
        }

        public async Task<IActionResult> ValidarClave(string Contrasenia)
        {
            var list = await _usuarioService.ValidarClave(Contrasenia);

            return Ok(list.Data);
        }

        [ResponseCache(Location = ResponseCacheLocation.None, NoStore = true)]
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
