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
    public class FacturaController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly FacturaService _facturaService;
        public FacturaController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _facturaService = new FacturaService(unitOfWork);
        }


        [HttpPost("venta")]
        public ActionResult<Response<FacturaResponse>> RegistrarVenta(CrearFacturaVentaRequest request)
        {
            var response=_facturaService.RegistrarVenta(request);
            return StatusCode((int)response.Code, response);
        }

        [HttpPost("compra")]
        public ActionResult<Response<FacturaResponse>> RegistrarCompra(CrearFacturaCompraRequest request)
        {
            var response= _facturaService.RegistrarCompra(request);
            return StatusCode((int)response.Code, response);
        }


        [HttpGet("venta")]
        public ActionResult<Response<IEnumerable<FacturaVentaResponse>>> ListarVentas()
        {

            var response= _facturaService.ListarVentas();
            return StatusCode((int)response.Code, response);
        }

        [HttpGet("compra")]
        public ActionResult<Response<IEnumerable<FacturaCompraResponse>>> ListarCompras()
        {

            var response= _facturaService.ListarCompras();
            return StatusCode((int)response.Code, response);
        }
    }
}
