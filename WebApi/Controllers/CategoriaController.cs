using Application.Base;
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
    public class CategoriaController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly CategoriaService _categoriaService;
        public CategoriaController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _categoriaService = new CategoriaService(unitOfWork);
        }

        [HttpGet]
        public ActionResult<Response<IEnumerable<CategoriaResponse>>> Listar()
        {

            return _categoriaService.Listar();
        }

    }
}