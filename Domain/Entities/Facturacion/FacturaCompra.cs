using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Facturacion
{
    [Table("Compras")]
    public class FacturaCompra:Factura
    {
        public int ProvedorId { get; set; }
        public Proovedor Provedor { get; set; }

        public ICollection<DetalleCompra> Compras { get; set; }
        [NotMapped] public decimal Total => Compras.Sum(x => x.Costo);
    }
}
