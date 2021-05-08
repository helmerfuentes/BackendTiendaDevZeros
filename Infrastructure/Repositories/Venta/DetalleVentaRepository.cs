using Domain.Entities;
using Domain.Repositories;
using Infrastructure.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories.Venta
{
    public class DetalleVentaRepository : GenericRepository<DetalleVenta>, IDetalleVentaRepository
    {
        public DetalleVentaRepository(IDbContext context) : base(context)
        {

        }
    }
}
