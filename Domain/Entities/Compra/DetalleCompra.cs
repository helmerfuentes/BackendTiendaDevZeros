using Domain.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using Domain.Entities.Facturacion;

namespace Domain.Entities
{
    [Table("DetalleCompras")]
    public class DetalleCompra: Entity<int>
    {
        public DateTime Fecha { get; set; }
        public int Cantidad { get; set; }
        public decimal Costo { get; set; }

        public int ProductoId { get; set; }
        public Producto Producto { get; set; }

        public int FacturaCompraId { get; set; }
        public FacturaCompra FacturaCompra { get; set; }


    }
}
