using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Http.Requests
{
    public class CrearDetalleVentaRequest
    {
        public int ProductoId { get; set; }
        public int Cantidad { get; set; }
        public decimal Costo { get; set; }
        public decimal Descuento { get; set; }
    }
}
