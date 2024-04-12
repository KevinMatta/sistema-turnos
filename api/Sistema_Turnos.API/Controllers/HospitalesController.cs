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
    public class HospitalesController : Controller
    {
        private readonly TurnoService _turnoService;
        private readonly GeneralService _generalService;
        private readonly IMapper _mapper;

        public HospitalesController(TurnoService turnoService, IMapper mapper, GeneralService generalService)
        {
            _turnoService = turnoService;
            _mapper = mapper;
            _generalService = generalService;
        }

        //Hospitales
        [HttpGet("ListTurnosHospitales")]
        public IActionResult Index()
        {
            var list = _turnoService.ListHospitales();
            return Ok(list);
        }

        [HttpPost("CreateHospitales")]
        public IActionResult Insert(HospitalViewModel item)
        {
            var model = _mapper.Map<tbHospitales>(item);
            var modelo = new tbHospitales()
            {
                Hosp_Descripcion = item.Hosp_Descripcion,
                Hosp_Direccion = item.Hosp_Direccion,
                Ciud_Id = item.Ciud_Id,
                Hosp_Creacion = item.Hosp_Creacion,
                Hosp_FechaCreacion = DateTime.Now,
            };
            var list = _turnoService.InsertarHospitales(modelo);
            return Ok(list);
        }

        [HttpGet("FillHospitales/{id}")]

        public IActionResult Llenar(int id)
        {

            var list = _turnoService.ListHostpi(id);
            return Json(list);
        }

        [HttpPut("UpdateHospitales")]
        public IActionResult Update(HospitalViewModel item)
        {
            var model = _mapper.Map<tbHospitales>(item);
            var modelo = new tbHospitales()
            {
                Hosp_Id = item.Hosp_Id,
                Hosp_Descripcion = item.Hosp_Descripcion,
                Hosp_Direccion = item.Hosp_Direccion,
                Ciud_Id = item.Ciud_Id,
                Hosp_Creacion = item.Hosp_Creacion,
                Hosp_FechaCreacion = DateTime.Now,
            };
            var list = _turnoService.ActualizarHospitales(modelo);
            return Ok(list);
        }

        [HttpDelete("DeleteHospitales")]
        public IActionResult Delete(int id, int modificacion, DateTime fecha)
        {
            var list = _turnoService.EliminarHospitales(id, modificacion, fecha);
            return Ok(list);
        }

    }
}
