using Application.Base;
using Application.Http.Responses;
using Domain.Contract;
using Domain.Entities.Usuario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
   public class RolService:Service<Rol>
    {
        public RolService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {

        }

        public Response<IEnumerable<RolResponse>> Listar()
        {
            var roles = UnitOfWork.RolRepository.FindBy(includeProperties:"Permisos").ToList();

            return new Response<IEnumerable<RolResponse>>
            {
                Message = "Listado de Producto",
                Data = roles.ConvertAll(x => new RolResponse(x).Include(x.Permisos.ToList()))
            };


        }
    }
}
