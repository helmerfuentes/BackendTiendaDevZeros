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
            return _facturaService.RegistrarVenta(request);
        }

        [HttpPost("compra")]
        public ActionResult<Response<FacturaResponse>> RegistrarCompra(CrearFacturaCompraRequest request)
        {
            return _facturaService.RegistrarCompra(request);
        }


        [HttpGet("venta")]
        public ActionResult<Response<IEnumerable<FacturaVentaResponse>>> ListarVentas()
        {

            return _facturaService.ListarVentas();
        }

        [HttpGet("compra")]
        public ActionResult<Response<IEnumerable<FacturaCompraResponse>>> ListarCompras()
        {

            return _facturaService.ListarCompras();
        }
    }
}
