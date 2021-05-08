using Application.Base;
using Application.Http.Requests;
using Application.Http.Responses;
using Application.Services;
using Domain.Contract;
using Microsoft.AspNetCore.Authorization;
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
    public class ProductoController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ProductoService _productoService;
        public ProductoController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _productoService = new ProductoService(_unitOfWork);
        }


        [HttpGet]
        public ActionResult<Response<IEnumerable<ProductoResponse>>> Listar()
        {
            var response=_productoService.Listar();
            return StatusCode((int)response.Code, response);
        }

        [HttpGet("PorCategoria")]
        public ActionResult<Response<IEnumerable<ProductoResponse>>> ListarCategoria([FromQuery]int id)
        {
            var response = _productoService.ListarPorCategoria(id);
            return StatusCode((int)response.Code, response);
        }

        [HttpGet("disponibles")]
        public ActionResult<Response<IEnumerable<ProductoResponse>>> ListarDisponibles()
        {
            var response = _productoService.ListarDisponible();
            return StatusCode((int)response.Code, response);
        }

        [HttpPost]
        public ActionResult<Response<CrearProductoResponse>>Registrar(CrearProductoRequest request)
        {
            var response= _productoService.Registrar(request);
            return StatusCode((int)response.Code, response);
        }
    }
}
