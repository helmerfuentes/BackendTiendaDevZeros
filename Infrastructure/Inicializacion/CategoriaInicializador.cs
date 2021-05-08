using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Inicializacion
{
    public static class CategoriaInicializador
    {
        public static void InicializadorCategoria(MyContext ctx)
        {
            var categorias =new  List<Categoria>();

            categorias.Add(new Categoria { Id = 1, Nombre = "Alimento", Descripcion = "todo lo relacionado en comida" });
            categorias.Add(new Categoria { Id = 2, Nombre = "Papeleria", Descripcion = "todo lo relacionado en papeleria" });
            categorias.Add(new Categoria { Id = 3, Nombre = "computo", Descripcion = "todo lo relacionado con computo" });
            ctx.AddRange(categorias);
            ctx.SaveChanges();
        }
    }
}
