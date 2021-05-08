using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Http.Responses
{
    public class CategoriaResponse
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public List<ProductoResponse>Productos { get; set; }

        public CategoriaResponse(Categoria categoria)
        {
            Id = categoria.Id;
            Nombre = categoria.Nombre;
            Descripcion = categoria.Descripcion;

        }

        public CategoriaResponse Include(List<Producto> productos)
        {
            if (productos!=null)
            {
                Productos = productos.ConvertAll(x => new ProductoResponse(x));
            }
            return this;

        }

    }
}
