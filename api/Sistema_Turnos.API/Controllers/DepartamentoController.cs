using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Sistema_Turnos.BusinessLogic.Services;
using Sistema_Turnos.Common;
using Sistema_Turnos.Entities.Entities;
using AutoMapper;
using Sistema_Turnos.Common.Models;

namespace Sistema_Turnos.API.Controllers
{
    [ApiController]
    [Route("/API/[controller]")]
    public class DepartamentoController : Controller
    {
        private readonly GeneralService _generalService;
        private readonly IMapper _mapper;

        public DepartamentoController(GeneralService generalService, IMapper mapper)
        {
            _generalService = generalService;
            _mapper = mapper;
        }

        [HttpGet("ListadoDepartamentos")]
        public IActionResult Index()
        {
            var list = _generalService.ListEstado();
            return Ok(list);
        }

        [HttpPost("CreateDepartamentos")]
        public IActionResult Insert(DepartamentoViewModel item)
        {
            var model = _mapper.Map<tbEstados>(item);
            var modelo = new tbEstados()
            {
                Esta_Id = item.Esta_Id,
                Esta_Descripcion = item.Esta_Descripcion,
                Esta_Creacion = item.Esta_Creacion,
                Esta_FechaCreacion = item.Esta_FechaCreacion,
            };
            var list = _generalService.InsertarEstado(modelo);
            return Ok(list);
        }

        [HttpDelete("DeleteDepartamentos")]
        public IActionResult Delete(string Esta_Id)
        {
            var list = _generalService.EliminarEstado(Esta_Id);
            return Ok(list);
        }

        [HttpGet("FillDepartamentos/{id}")]

        public IActionResult Llenar(string id)
        {

            var list = _generalService.ListDepto(id);
            return Json(list);
        }

        [HttpPut("UpdateDepartamentos")]
        public IActionResult Update(DepartamentoViewModel item)
        {
            var model = _mapper.Map<tbEstados>(item);
            var modelo = new tbEstados()
            {
                Esta_Id = item.Esta_Id,
                Esta_Descripcion = item.Esta_Descripcion,
                //Esta_Modificacion = 1,
                //Esta_FechaModificacion = DateTime.Now,
            };
            var list = _generalService.ActualizarEstado(modelo);
            return Ok(list);
        }

        [HttpGet("DetailsDepartamentos")]
        public IActionResult Details(string Esta_Id)
        {
            var list = _generalService.ListDepto(Esta_Id);
            return Ok(list);
        }

        [HttpGet("ObetenerEstado")]
        public IActionResult ObtenerEstado(string Esta_Descripcion)
        {
            var list = _generalService.ObtenerEsta(Esta_Descripcion);
            return Ok(list);
        }

    }
}
