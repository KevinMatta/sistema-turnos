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
    public class TurnoController : Controller
    {
        private readonly TurnoService _turnoService;
        private readonly IMapper _mapper;

        public TurnoController(TurnoService turnoService, IMapper mapper)
        {
            _turnoService = turnoService;
            _mapper = mapper;
        }
        [HttpGet("ListarTurnos")]
        public IActionResult Index()
        {
            var list = _turnoService.ListTurnos();
            return Ok(list);
        }

        [HttpPost("CreateTurnos")]
        public IActionResult Insert(TurnoViewModel item)
        {
            var model = _mapper.Map<tbTurnos>(item);
            var modelo = new tbTurnos()
            {
                Turn_Descripcion = item.Turn_Descripcion,
                Turn_HoraEntrada = item.Turn_HoraEntrada,
                Turn_HoraSalida = item.Turn_HoraSalida,
                Turn_Creacion = item.Turn_Creacion,
                Turn_FechaCreacion = DateTime.Now,
            };
            var list = _turnoService.InsertarTurnos(modelo);
            return Ok(list);
        }

        [HttpGet("FillTurnos/{id}")]

        public IActionResult Llenar(int id)
        {

            var list = _turnoService.ListTurn(id);
            return Json(list);
        }

        [HttpPut("UpdateTurnos")]
        public IActionResult Update(TurnoViewModel item)
        {
            var model = _mapper.Map<tbTurnos>(item);
            var modelo = new tbTurnos()
            {
                Turn_Id = item.Turn_Id,
                Turn_Descripcion = item.Turn_Descripcion,
                Turn_HoraEntrada = item.Turn_HoraEntrada,
                Turn_HoraSalida = item.Turn_HoraSalida,
                Turn_Modificacion = item.Turn_Modificacion,
                Turn_FechaModificacion = DateTime.Now,
            };
            var list = _turnoService.ActualizarTurnos(modelo);
            return Ok(list);
        }

        [HttpDelete("DeleteTurnos")]
        public IActionResult Delete(int id, int modificacion, DateTime fecha)
        {
            var list = _turnoService.EliminarTurnos(id, modificacion, fecha);
            return Ok(list);
        }

    }
}
