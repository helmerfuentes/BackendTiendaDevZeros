using Domain.Entities.Usuario;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Facturacion
{
    [Table("Ventas")]
    public class FacturaVenta : Factura
    {
        public int PersonaId { get; set; }
        public decimal ValorTotalDescontaado { get; set; }
        public Persona Persona{ get; set; }
        public ICollection<DetalleVenta> Ventas { get; set; }
        [NotMapped] public decimal Total => Ventas.Sum(x => x.ValorUnitario);
    }
}
