using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Http.Requests
{
   public class CrearProductoRequest
    {
        public int Id;
        public string Codigo { get; set; }
        public decimal Iva { get; set; }
        public decimal Precio { get; set; }
        public decimal PorcentajeMaxDescuento { get; set; }
        public string Nombre { get; set; }
        public decimal PorcentajeUtilidad { get; set; }

        public int CategoriaId { get; set; }
    }
}
