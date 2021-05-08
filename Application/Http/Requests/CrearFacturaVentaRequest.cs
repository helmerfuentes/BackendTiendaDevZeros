using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Http.Requests
{
    public class CrearFacturaVentaRequest
    {
        public List<CrearDetalleVentaRequest> DetallesProducto { get; set; }
        public int PersonaId { get; set; }

        public List<int> NumeroproductosPorId => DetallesProducto?.ConvertAll(x => x.ProductoId);
        // public decimal ValorDeLaFactura => DetallesProducto.Sum(x => x.Costo);
    }
}
