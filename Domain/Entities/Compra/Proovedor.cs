using Domain.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    [Table("Proovedores")]
    public class Proovedor: Entity<int>
    {
        public string Nit { get; set; }
        public string Telefono { get; set; }
        public string Direccion { get; set; }
        public string Nombre { get; set; }
        public string RazonSocial{ get; set; }
    }
}


