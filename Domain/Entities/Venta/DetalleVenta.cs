using Domain.Base;
using Domain.Entities.Facturacion;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    [Table("DetalleVenta")]
    public class DetalleVenta: Entity<int>
    {
        public decimal  ValorUnitario{ get; set; }
        public decimal Descuento { get; set; }
        public DateTime Fecha { get; set; }
        public int Cantidad { get; set; }
        public int ProductoId { get; set; }
        public Producto Producto { get; set; }
        public int FacturaVentaId { get; set; }
        public FacturaVenta FacturaVenta { get; set; }
    }
}
