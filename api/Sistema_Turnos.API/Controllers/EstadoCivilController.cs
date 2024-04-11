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
    public class EstadoCivilController : Controller
    {

        private readonly GeneralService _generalService;
        private readonly IMapper _mapper;
        public EstadoCivilController(GeneralService generalService, IMapper mapper)
        {
            _generalService = generalService;
            _mapper = mapper;
        }

        [HttpGet("ListadoEstadosCiviles")]
        public IActionResult Index()
        {
            var list = _generalService.ListEstadosCiviles();
            return Ok(list);
        }

        [HttpPost("CreateEstadosCiviles")]
        public IActionResult Insert(EstadoCivilViewModel item)
        {
            var model = _mapper.Map<tbEstadosCiviles>(item);
            var modelo = new tbEstadosCiviles()
            {
                EsCi_Descripcion = item.EsCi_Descripcion,
                EsCi_Creacion = item.EsCi_Creacion,
                EsCi_FechaCreacion = DateTime.Now,
            };
            var list = _generalService.InsertarEstadosCiviles(modelo);
            return Ok(list);
        }

        [HttpGet("FillEstadosCiviles/{id}")]

        public IActionResult Llenar(int id)
        {

            var list = _generalService.ListEstadosCiv(id);
            return Json(list);
        }

        [HttpPut("UpdateEstadosCiviles")]
        public IActionResult Update(EstadoCivilViewModel item)
        {
            var model = _mapper.Map<tbEstadosCiviles>(item);
            var modelo = new tbEstadosCiviles()
            {
                EsCi_Id = item.EsCi_Id,
                EsCi_Descripcion = item.EsCi_Descripcion,
                EsCi_Modificacion = item.EsCi_Modificacion,
                EsCi_FechaModificacion = DateTime.Now,
            };
            var list = _generalService.ActualizarEstadosCiviles(modelo);
            return Ok(list);
        }

        [HttpDelete("DeleteEstadosCiviles")]
        public IActionResult Delete(int EsCi_Id, int EsCi_Modificacion, DateTime EsCi_FechaModificacion)
        {
            var list = _generalService.EliminarEstadosCiviles(EsCi_Id, EsCi_Modificacion, EsCi_FechaModificacion);
            return Ok(list);
        }

    }
}
