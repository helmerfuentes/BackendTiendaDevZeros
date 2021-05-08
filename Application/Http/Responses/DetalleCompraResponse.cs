using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Http.Responses
{
   public class DetalleCompraResponse
    {
        public int Id { get; set; }
        public int Cantidad { get; set; }
        public decimal Costo { get; set; }
        public DateTime Fecha { get; set; }
        public ProductoResponse Producto { get; set; }

        public DetalleCompraResponse(DetalleCompra detalle)
        {
            Id = detalle.Id;
            Cantidad = detalle.Cantidad;
            Costo = detalle.Costo;
            Fecha = detalle.Fecha;
        }

        public DetalleCompraResponse Include(Producto producto)
        {
            if (producto!=null)
            {
            Producto = new ProductoResponse(producto);
            }
            return this;
        }

    }
}
