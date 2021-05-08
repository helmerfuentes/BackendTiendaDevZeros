using Application.Base;
using Application.Http.Requests;
using Application.Http.Responses;
using Application.Services;
using Domain.Contract;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
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

            return _productoService.Listar();
        }

        [HttpPost]
        public ActionResult<Response<CrearProductoResponse>>Registrar(CrearProductoRequest request)
        {
            return _productoService.Registrar(request);
        }
    }
}
