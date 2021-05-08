using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Http.Responses
{
    public class CrearProductoResponse
    {
        public decimal Iva { get; set; }
        public decimal Precio { get; set; }
        public decimal PorcentajeMaxDescuento { get; set; }
        public string Nombre { get; set; }
        public decimal PorcentajeUtilidad { get; set; }
        public int CantidadDisponible { get; set; }

        public string Categoria { get; set; }
    }
}
