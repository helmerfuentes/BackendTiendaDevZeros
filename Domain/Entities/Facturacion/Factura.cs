using Domain.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    [Table("Facturas")]
    public abstract class Factura:Entity<int>
    {
        public decimal Valor { get; set; }
        public DateTime Fecha { get; set; }
    }
}
