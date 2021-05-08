using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Http.Responses
{
    public class ProductoResponse
    {
        public int Id { get; set; }
        public decimal Iva { get; set; }
        public decimal Precio { get; set; }
        public decimal PorcentajeMaxDescuento { get; set; }
        public string Nombre { get; set; }
        public decimal PorcentajeUtilidad { get; set; }
        public int CantidadDisponible { get; set; }
        public string Categoria { get; set; }

        public ProductoResponse(Producto producto)
        {
            Iva = producto.Iva;
            Precio = producto.Precio;
            PorcentajeMaxDescuento = producto.PorcentajeMaxDescuento;
            Nombre = producto.Nombre;
            PorcentajeUtilidad = producto.PorcentajeUtilidad;
            CantidadDisponible = producto.CantidadDisponible;
            Id = producto.Id;
        }

        public ProductoResponse Include(Categoria categoria)
        {
            if (categoria!=null)
            {
                Categoria = categoria.Nombre;
            }
            return this;
        }

    
       
    }
}
