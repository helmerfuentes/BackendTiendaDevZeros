using Application.Base;
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
    public class ProovedorController
    {
        private readonly IUnitOfWork _iuniOfWork;
        private readonly ProovedorService _provedorService;
        public ProovedorController(IUnitOfWork unitOfWork)
        {
            _iuniOfWork = unitOfWork;
            _provedorService = new ProovedorService(unitOfWork);
        }

           [HttpGet]
        public ActionResult<Response<IEnumerable<ProovedorResponse>>> Listar()
        {

            return _provedorService.Listar();
        }
    }
}
