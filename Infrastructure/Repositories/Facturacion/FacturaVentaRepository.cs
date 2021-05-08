using Domain.Entities;
using Domain.Entities.Facturacion;
using Domain.Repositories;
using Infrastructure.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories.Facturacion
{
    public class FacturaVentaRepository : GenericRepository<FacturaVenta>, IFacturaVentaRepository
    {
        public FacturaVentaRepository(IDbContext context) : base(context)
        {

        }
    }
}
