using Domain.Entities;
using Domain.Entities.Facturacion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Builder
{
    public static class FacturaVentaBuilder
    {
        private static ICollection<DetalleVenta> detalles;
        public static void Inicializar()
        {
            detalles = new List<DetalleVenta>();
        }
        public static void AgregarDetalle(decimal porcentajeDescuento, Producto producto, decimal valorUnitario,int cantidad)
        {
            if (producto.QuitarProducto(cantidad))
            {
                var detalle = new DetalleVenta
                {
                    PorcentajeDescuento = porcentajeDescuento,
                    ValorDescuento= (valorUnitario*cantidad)/(porcentajeDescuento/100),
                    Fecha = DateTime.Now,
                    Producto = producto,
                    ValorUnitario = valorUnitario,
                    Cantidad = cantidad,
                    ValorTotalProductos= (valorUnitario * cantidad) - (valorUnitario * cantidad) * (porcentajeDescuento / 100)
                };

                detalles.Add(detalle);
            }
            else
            
                throw new Exception("Cantidad no disponible");
            
           
        }
        public static FacturaVenta Build(int personaId)
        {
            if (detalles is null)
            {
                throw new Exception("Error al generar factura");
            }
            var factura = new FacturaVenta
            {
                PersonaId = personaId,
                Fecha = DateTime.Now,
                Ventas = detalles,
                ValorTotalDescontaado = detalles.Sum(x => x.ValorDescuento),
                Valor=detalles.Sum(x=>(x.ValorTotalProductos))
            };
            detalles = default;
            return factura;
        }
    }

    public static class FacturaCompraBuilder
    {
        private static FacturaCompra _facturaCompra = new FacturaCompra();
        private static ICollection<DetalleCompra> detalles;
        public static void Inicializar()
        {
            detalles = new List<DetalleCompra>();
        }
        public static void AgregarDetalle(int cantidad, Producto producto, decimal costo)
        {
            var detalle = new DetalleCompra
            {
                Cantidad = cantidad,
                Fecha = DateTime.Now,
                Producto = producto,
                Costo = costo,

            };
            producto.CantidadDisponible += cantidad;
            detalles.Add(detalle);
        }

        public static FacturaCompra Build(int provedorId)
        {
            if (detalles is null)
            {
                throw new Exception("Error al generar factura");
            }
            var factura = new FacturaCompra
            {
                ProvedorId = provedorId,
                Fecha = DateTime.Now,
                Compras=detalles,
                Valor=detalles.Sum(x=>x.Costo)
            };
            detalles = default;
            return factura;
        } 
    }
}
