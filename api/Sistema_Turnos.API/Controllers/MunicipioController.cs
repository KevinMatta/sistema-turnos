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
    public class MunicipioController : Controller
    {

        private readonly GeneralService _generalService;
        private readonly IMapper _mapper;

        public MunicipioController(GeneralService generalService, IMapper mapper)
        {
            _generalService = generalService;
            _mapper = mapper;
        }

        [HttpGet("ListadoMunicipios")]
        public IActionResult Index()
        {
            var list = _generalService.ListMunicipio();
            return Ok(list);
        }

        [HttpPost("CreateMunicipios")]
        public IActionResult Insert(MunicipioViewModel item)
        {
            var model = _mapper.Map<tbCiudades>(item);
            var modelo = new tbCiudades()
            {
                Ciud_Id = item.Ciud_Id,
                Esta_Id = item.Esta_Id,
                Ciud_Descripcion = item.Ciud_Descripcion,
                Ciud_Creacion = item.Ciud_Creacion,
                Ciud_FechaCreacion = item.Ciud_FechaCreacion,
            };
            var list = _generalService.InsertarMunicipio(modelo);
            return Ok(list);
        }

        [HttpGet("FillMunicipio/{id}")]

        public IActionResult Llenar(string id)
        {

            var list = _generalService.ListMunic(id);
            return Json(list);
        }

        [HttpPut("UpdateMunicipio")]
        public IActionResult Update(MunicipioViewModel item)
        {
            var model = _mapper.Map<tbCiudades>(item);
            var modelo = new tbCiudades()
            {
                Ciud_Id = item.Ciud_Id,
                Ciud_Descripcion = item.Ciud_Descripcion,
                Esta_Id = item.Esta_Id,
                Ciud_Modificacion = item.Ciud_Modificacion,
                Ciud_FechaModificacion = DateTime.Now,
            };
            var list = _generalService.ActualizarMunicipio(modelo);
            return Ok(list);
        }

        [HttpDelete("DeleteMunicipio")]
        public IActionResult Delete(string Ciud_Id)
        {
            var list = _generalService.EliminarMunicipio(Ciud_Id);
            return Ok(list);
        }

    }
}
