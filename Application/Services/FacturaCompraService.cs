using Application.Base;
using Domain.Contract;
using Domain.Entities.Facturacion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
   public class FacturaCompraService:Service<FacturaCompra>
    {
        public FacturaCompraService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {

        }
    }
}
