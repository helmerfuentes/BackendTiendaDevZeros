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
    public class UsuarioController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly UsuarioService _usuarioService;
        public UsuarioController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _usuarioService = new UsuarioService(_unitOfWork);


        }

        [HttpPost("login")]
        [AllowAnonymous]
        public ActionResult<Response<LoginUserResponse>> Login(LoginUserRequest request)
        {

            var response= _usuarioService.Autenticar(request);
            return StatusCode((int)response.Code, response);
        }

        [HttpPost("registrar")]
        public ActionResult<Response<CrearUsuarioResponse>> Registrar(CrearUsuarioRequest request)
        {

            var response= _usuarioService.Registrar(request);
            return StatusCode((int)response.Code, response);
        }

        [HttpGet]
        public ActionResult<Response<IEnumerable<UsuarioResponse>>> Listar()
        {

            var response= _usuarioService.Listar();
            return StatusCode((int)response.Code, response);
        }



    }
}
