using Application.Base;
using Application.Http.Requests;
using Application.Http.Responses;
using Application.Services;
using Domain.Contract;
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
        public ActionResult<Response<LoginUserResponse>> login(LoginUserRequest request)
        {

            return _usuarioService.Autenticar(request);
        }

        [HttpPost("registrar")]
        public ActionResult<Response<CrearUsuarioResponse>> registrar(CrearUsuarioRequest request)
        {

            return _usuarioService.Registrar(request);
        }



    }
}
