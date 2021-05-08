using Domain.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    [Table("Productos")]
    public class Producto: Entity<int>
    {
        public string Codigo { get; set; }
        public decimal Iva { get; set; }
        public decimal Precio { get; set; }
        public decimal PorcentajeMaxDescuento { get; set; }
        public string Nombre { get; set; }
        public decimal PorcentajeUtilidad { get; set; }
        public int CantidadDisponible { get; set; }

        public int CategoriaId { get; set; }
        public Categoria Categoria { get; set; }
        public ICollection<DetalleCompra> DetalleCompras { get; set; }
        public ICollection<DetalleVenta> DetalleVentas{ get; set; }




        public bool QuitarProducto(int cantidad) {
            if (CantidadDisponible>=cantidad)
            {
                CantidadDisponible -= cantidad;
                return true;
            }
            return false;
        } 
    }
}
