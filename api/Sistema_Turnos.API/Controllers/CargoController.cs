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
    public class CargoController : Controller
    {
        private readonly GeneralService _generalService;
        private readonly IMapper _mapper;
        public CargoController(GeneralService generalService, IMapper mapper)
        {
            _generalService = generalService;
            _mapper = mapper;
        }

        [HttpGet("ListadoCargos")]
        public IActionResult Index()
        {
            var list = _generalService.ListCargo();
            return Ok(list);
        }

        [HttpPost("CreateCargos")]
        public IActionResult Insert(CargoViewModel item)
        {
            var model = _mapper.Map<tbCargos>(item);
            var modelo = new tbCargos()
            {
                Carg_Descripcion = item.Carg_Descripcion,
                Carg_Creacion = item.Carg_Creacion,
                Carg_FechaCreacion = DateTime.Now,
            };
            var list = _generalService.InsertarCargo(modelo);
            return Ok(list);
        }

        [HttpGet("FillCargos/{id}")]

        public IActionResult Llenar(int id)
        {

            var list = _generalService.ListCar(id);
            return Json(list);
        }

        [HttpPut("UpdateCargos")]
        public IActionResult Update(CargoViewModel item)
        {
            var model = _mapper.Map<tbCargos>(item);
            var modelo = new tbCargos()
            {
                Carg_Id = item.Carg_Id,
                Carg_Descripcion = item.Carg_Descripcion,
                Carg_Modificacion = item.Carg_Modificacion,
                Carg_FechaModificacion = DateTime.Now,
            };
            var list = _generalService.ActualizarCargo(modelo);
            return Ok(list);
        }

        [HttpDelete("DeleteCargos")]
        public IActionResult Delete(int Carg_Id, int Carg_Modificacion, DateTime Carg_FechaModificacion)
        {
            var list = _generalService.EliminarCargo(Carg_Id, Carg_Modificacion, Carg_FechaModificacion);
            return Ok(list);
        }

    }
}
