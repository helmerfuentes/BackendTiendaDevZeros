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
    public class CategoriaService: Service<Categoria>
    {

        public CategoriaService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
          
        }


        public Response<IEnumerable<CategoriaResponse>> Listar()
        {
            var cateogiras = UnitOfWork.CategoriaRepository.FindBy().ToList();

            return new Response<IEnumerable<CategoriaResponse>>("Listado de Producto",
                data: cateogiras.ConvertAll(x => new CategoriaResponse(x)));
        }
        public Response<IEnumerable<CategoriaResponse>> CategoriaConProductoDisponible()
        {
            var cateogiras = UnitOfWork.CategoriaRepository.FindBy().ToList();

            return new Response<IEnumerable<CategoriaResponse>>("Listado de Producto",
                data: cateogiras.ConvertAll(x => new CategoriaResponse(x).Include(x.Productos.ToList())));
        }
    }
}
