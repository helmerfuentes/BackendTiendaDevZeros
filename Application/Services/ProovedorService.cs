using Application.Base;
using Application.Http.Responses;
using Domain.Contract;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
   public class ProovedorService: Service<Proovedor>
    {
        public ProovedorService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {

        }

        public Response<IEnumerable<ProovedorResponse>> Listar()
        {
            var provedores = UnitOfWork.ProvedorRepository.FindBy().ToList();
            return new Response<IEnumerable<ProovedorResponse>>("Listado de Provedores",
              data: provedores.ConvertAll(x => new ProovedorResponse(x)));
        }
    }
}
