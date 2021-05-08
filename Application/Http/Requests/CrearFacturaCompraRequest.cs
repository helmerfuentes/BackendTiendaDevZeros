using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Http.Requests
{
   public class CrearFacturaCompraRequest
    {
        public List<CrearDetalleCompraRequest> DetallesCompra{ get; set; }
        public int ProovedorId { get; set; }

        public List<int> NumeroproductosPorId => DetallesCompra?.ConvertAll(x => x.ProductoId);

    }
}
