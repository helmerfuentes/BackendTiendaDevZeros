using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Http.Responses
{
    public class FacturaResponse
    {
        public int Id{ get; set; }
        public decimal Valor { get; set; }
        public DateTime Fecha { get; set; }
        public string Nombre { get; set; }
        public string Tipo { get; set; }
    }
}
