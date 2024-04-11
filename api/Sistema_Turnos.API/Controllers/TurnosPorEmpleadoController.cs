using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Sistema_Turnos.BusinessLogic.Services;
using Sistema_Turnos.Common.Models;
using Sistema_Turnos.Entities.Entities;
using Sistema_Turnos.DataAccess.Repository;
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

        [HttpPost("Crear")]
        public IActionResult Insert(TurnosPorEmpleadoViewModel item)
        {
            var modelo = new tbTurnosPorEmpleados()
            {
                TuEm_FechaInicio = item.TuEm_FechaInicio,
                Turn_Id = item.Turn_Id,
                Empl_Id = item.Empl_Id,
                TuEm_Creacion = item.TuEm_Creacion,
                TuEm_FechaCreacion = item.TuEm_FechaCreacion,
            };
            var list = _turnoService.InsertarTurnoEmpleado(modelo);
            return Ok(list);
        }

        [HttpPut("Editar")]
        public IActionResult Update(TurnosPorEmpleadoViewModel item)
        {
            var modelo = new tbTurnosPorEmpleados()
            {
                TuEm_Id = item.TuEm_Id,
                TuEm_FechaInicio = item.TuEm_FechaInicio,
                Turn_Id = item.Turn_Id,
                Empl_Id = item.Empl_Id,
                TuEm_Modificacion = item.TuEm_Modificacion,
                TuEm_FechaModificacion = item.TuEm_FechaModificacion,
            };
            var list = _turnoService.ActualizarTurnoEmpleado(modelo);
            return Ok(list);
        }

        [HttpDelete("Eliminar")]
        public IActionResult Delete(int id)
        {
            var list = _turnoService.EliminarTurnoEmpleado(id);
            return Ok(list);
        }

        [HttpGet("Buscar/{id}")]
        public IActionResult Details(int id)
        {
            var list = _turnoService.BuscarTurnoEmpleado(id);
            return Ok(list);
        }

        [HttpGet("ContarTurnosEmpleados/{FechaInicio}/{FechaFin}")]
        public IActionResult ContarTurnos(string FechaInicio, string FechaFin)
        {
            var list = _turnoService.ContarTurnos(FechaInicio, FechaFin);
            return Ok(list);
        }

    }
}
