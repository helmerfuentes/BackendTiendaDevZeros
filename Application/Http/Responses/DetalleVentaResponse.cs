using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Http.Responses
{
    public class DetalleVentaResponse
    {
        public decimal ValorUnitario { get; set; }
        public decimal Descuento { get; set; }
        public DateTime Fecha { get; set; }

        public ProductoResponse Producto { get; set; }
        public DetalleVentaResponse(DetalleVenta detalleVenta)
        {
            ValorUnitario = detalleVenta.ValorUnitario;
            Descuento = detalleVenta.PorcentajeDescuento;
            Fecha = detalleVenta.Fecha;
        }

        public DetalleVentaResponse Include(Producto producto)
        {
            if (producto!=null)
            {
                Producto = new ProductoResponse(producto);
            }
            return this;
        }



    

    }
}
