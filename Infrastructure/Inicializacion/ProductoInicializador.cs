using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Inicializacion
{
   public static class ProductoInicializador
    {
        public static void InicializadorProducto(MyContext ctx)
        {
            var productos = new List<Producto>();
            productos.Add(new Producto { Id = 1, Nombre = "pepino", CategoriaId=1,Iva=18,Codigo="SDSD3TR",Precio=1000,PorcentajeUtilidad=2,PorcentajeMaxDescuento=1,CantidadDisponible=0});
            productos.Add(new Producto { Id = 2, Nombre = "Tomate", CategoriaId=2,Iva=18,Codigo="33333TR",Precio=2000, PorcentajeUtilidad = 2, PorcentajeMaxDescuento = 1, CantidadDisponible = 1 });
            ctx.Productos.AddRange(productos);
            ctx.SaveChanges();
        }
    }
}
