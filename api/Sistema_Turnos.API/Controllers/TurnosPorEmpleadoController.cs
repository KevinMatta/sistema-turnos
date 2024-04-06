using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Sistema_Turnos.BusinessLogic.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sistema_Turnos.API.Controllers
{
    [ApiController]
    [Route("/API/[controller]")]
    public class TurnosPorEmpleadoController : Controller
    {
        
        private readonly TurnoService _turnoService;
        private readonly IMapper _mapper;

        public TurnosPorEmpleadoController(TurnoService turnoService, IMapper mapper)
        {
            _turnoService = turnoService;
            _mapper = mapper;
        }
        [HttpGet("ListTurnosEmpleados")]
        public IActionResult Index()
        {
            var list = _turnoService.ListTurnoEmpleado();
            return Ok(list);
        }
    }
}
