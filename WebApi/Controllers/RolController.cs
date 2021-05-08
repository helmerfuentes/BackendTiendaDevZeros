using Application.Base;
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
    public class RolController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly RolService _rolService;
        public RolController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _rolService= new RolService(unitOfWork);
        }

        [HttpGet]
        public ActionResult<Response<IEnumerable<RolResponse>>> Listar()
        {

            var response= _rolService.Listar();
            return StatusCode((int)response.Code, response);
        }
    }
}
