using Domain.Entities;
using Domain.Entities.Facturacion;
using Domain.Entities.Usuario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Http.Responses
{
    public class FacturaVentaResponse
    {
        public DateTime Fecha { get; set; }
        public decimal Valor { get; set; }
        public PersonaResponse Persona { get; set; }
        public List<DetalleVentaResponse> Productos { get; set; }


        public FacturaVentaResponse (FacturaVenta factura)
        {
            Valor = factura.Valor;
            Fecha = factura.Fecha;

        }

        public FacturaVentaResponse Include(Persona persona)
        {
            if (persona != null)
            {
                Persona = new PersonaResponse(persona);
            }

            return this;
        }

        public FacturaVentaResponse Include(List<DetalleVenta> detalles)
        {
            if (detalles != null)
            {
                Productos = detalles.ConvertAll(x => new DetalleVentaResponse(x).Include(x.Producto));
            }
            return this;
        }

    }
}
