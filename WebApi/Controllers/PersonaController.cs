using Application.Base;
using Application.Http.Requests;
using Application.Http.Responses;
using Application.Services;
using Domain.Contract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class PersonaController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly PersonaService _personaService;
        public PersonaController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _personaService = new PersonaService(unitOfWork);
        }

        [HttpPost]
        public ActionResult<Response<PersonaResponse>> Registrar(CrearPersonaRequest request)
        {
            var response= _personaService.Registrar(request);
            return StatusCode((int)response.Code, response);
        }

        [HttpGet]
        public ActionResult<Response<PersonaResponse>> BuscarPorDocumento([FromQuery]string documento)
        {
            var response = _personaService.BuscarPorDocumento(documento);
            return StatusCode((int)response.Code, response);
        }

    }
}
