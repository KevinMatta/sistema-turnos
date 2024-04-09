using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sistema_Turnos.Controllers
{
    public class MunicipioController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
