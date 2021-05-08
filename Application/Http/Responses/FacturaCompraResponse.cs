using Domain.Entities;
using Domain.Entities.Facturacion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Http.Responses
{
    public class FacturaCompraResponse
    {
        public int Id { get; set; }
        public decimal  Valor { get; set; }
        public DateTime Fecha { get; set; }
        public ProovedorResponse Provedor { get; set; }
        public List<DetalleCompraResponse> Productos { get; set; }

        public  FacturaCompraResponse(FacturaCompra factura)
        {
            Id = factura.Id;
            Valor = factura.Valor;
            Fecha = factura.Fecha;
        }

        public FacturaCompraResponse Include(Proovedor provedor)
        {
            if (provedor!=null)
            {
                Provedor = new ProovedorResponse(provedor);
            }
            return this;
        }

        public FacturaCompraResponse Include(List<DetalleCompra> detalles)
        {
            if (detalles != null)
            {
                Productos= detalles.ConvertAll(x => new DetalleCompraResponse(x).Include(x.Producto));
            }
            return this;
        }
    }
}
