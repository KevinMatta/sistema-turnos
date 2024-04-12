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
    public class PersonaController : Controller
    {

        private readonly GeneralService _generalService;
        private readonly IMapper _mapper;
        public PersonaController(GeneralService generalService, IMapper mapper)
        {
            _generalService = generalService;
            _mapper = mapper;
        }

        [HttpGet("ListadoPersonas")]
        public IActionResult Index()
        {
            var list = _generalService.ListPersonas();
            return Ok(list);
        }

        [HttpPost("CreatePersonas")]
        public IActionResult Insert(PersonaViewModel item)
        {
            var model = _mapper.Map<tbPersonas>(item);
            var modelo = new tbPersonas()
            {
                Pers_Identidad = item.Pers_Identidad,
                Pers_PrimerNombre = item.Pers_PrimerNombre,
                Pers_SegundoNombre = item.Pers_SegundoNombre,
                Pers_PrimerApellido = item.Pers_PrimerApellido,
                Pers_SegundoApellido = item.Pers_SegundoApellido,
                Pers_Sexo = item.Pers_Sexo,
                EsCi_Id = item.EsCi_Id,
                Pers_Creacion = item.Pers_Creacion,
                Pers_FechaCreacion = DateTime.Now,
            };
            var list = _generalService.InsertarPersonas(modelo);
            return Ok(list);
        }

        [HttpGet("FillPersonas/{id}")]

        public IActionResult Llenar(string id)
        {

            PersonaViewModel persona = new PersonaViewModel();
            var list = _generalService.ListPerson(id);
            var lista = list.Data as IEnumerable<tbPersonas>;

            foreach (var item in lista.ToList())
            {
                persona.Pers_Identidad = item.Pers_Identidad;
                persona.Pers_PrimerNombre = item.Pers_PrimerNombre;
                persona.Pers_SegundoNombre = item.Pers_SegundoNombre;
                persona.Pers_PrimerApellido = item.Pers_PrimerApellido;
                persona.Pers_SegundoApellido = item.Pers_SegundoApellido;
                persona.Pers_Sexo = item.Pers_Sexo;
                persona.EsCi_Id = item.EsCi_Id;
                persona.Pers_Creacion = item.Pers_Creacion;
                persona.Pers_FechaCreacion = item.Pers_FechaCreacion;
            }
            return Ok(persona);
        }

        [HttpPut("UpdatePersonas")]
        public IActionResult Update(PersonaViewModel item)
        {
            var model = _mapper.Map<tbPersonas>(item);
            var modelo = new tbPersonas()
            {
                Pers_Identidad = item.Pers_Identidad,
                Pers_PrimerNombre = item.Pers_PrimerNombre,
                Pers_SegundoNombre = item.Pers_SegundoNombre,
                Pers_PrimerApellido = item.Pers_PrimerApellido,
                Pers_SegundoApellido = item.Pers_SegundoApellido,
                Pers_Sexo = item.Pers_Sexo,
                EsCi_Id = item.EsCi_Id,
                Pers_Modificacion = item.Pers_Creacion,
                Pers_FechaModificacion = DateTime.Now,
            };
            var list = _generalService.ActualizarPersonas(modelo);
            return Ok(list);
        }

        [HttpDelete("DeletePersonas")]
        public IActionResult Delete(int id, int modificacion, DateTime fecha)
        {
            var list = _generalService.EliminarPersonas(id, modificacion, fecha);
            return Ok(list);
        }

    }
}
