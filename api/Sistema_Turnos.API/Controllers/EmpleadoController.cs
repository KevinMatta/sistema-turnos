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
    public class EmpleadoController : Controller
    {
        private readonly TurnoService _turnoService;
        private readonly IMapper _mapper;

        public EmpleadoController(TurnoService turnoService, IMapper mapper)
        {
            _turnoService = turnoService;
            _mapper = mapper;
        }
        [HttpGet("ListarEmpledos")]
        public IActionResult Index()
        {
            var list = _turnoService.ListEmpleados();
            return Ok(list);
        }

        [HttpPost("CreateEmpleados")]
        public IActionResult Insert(EmpleadoViewModel item)
        {
            var model = _mapper.Map<tbEmpleados>(item);
            var modelo = new tbEmpleados()
            {
                Pers_Identidad = item.Pers_Identidad,
                Usua_Id = item.Usua_Id,
                Carg_Id = item.Carg_Id,
                Hosp_Id = item.Hosp_Id,
                Empl_Creacion = item.Empl_Creacion,
                Empl_FechaCreacion = DateTime.Now,
            };
            var list = _turnoService.InsertarEmpleados(modelo);
            return Ok(list);
        }

        [HttpGet("FillEmpleados{id}")]

        public IActionResult Llenar(int id)
        {

            var list = _turnoService.ListEmpl(id);
            return Json(list);
        }

        [HttpGet("TraerEmple/{id}")]

        public IActionResult TraerEmple(int id)
        {

            var list = _turnoService.TraerEmple(id);
            return Json(list);
        }

        [HttpPut("UpdateEmpleados")]
        public IActionResult Update(EmpleadoViewModel item)
        {
            var model = _mapper.Map<tbEmpleados>(item);
            var modelo = new tbEmpleados()
            {
                Empl_Id = item.Empl_Id,
                Pers_Identidad = item.Pers_Identidad,
                Usua_Id = item.Usua_Id,
                Carg_Id = item.Carg_Id,
                Hosp_Id = item.Hosp_Id,
                Empl_Modificacion = item.Empl_Modificacion,
                Empl_FechaModificacion = DateTime.Now,
            };
            var list = _turnoService.ActualizarEmpleados(modelo);
            return Ok(list);
        }

        [HttpDelete("DeleteEmpleados")]
        public IActionResult Delete(int id, int modificacion, DateTime fecha)
        {
            var list = _turnoService.EliminarEmpleados(id, modificacion, fecha);
            return Ok(list);
        }

    }
}
