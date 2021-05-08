using Application.Base;
using Domain.Contract;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class DetalleCompraService:Service<DetalleCompra>
    {
        public DetalleCompraService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {

        }
    }
}
