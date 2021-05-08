using Domain.Entities;
using Domain.Repositories;
using Infrastructure.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories.Compra
{
    public class DetalleCompraRepository : GenericRepository<DetalleCompra>, IDetalleCompraRepository
    {
        public DetalleCompraRepository(IDbContext context):base(context)
        {

        }
    }
}
