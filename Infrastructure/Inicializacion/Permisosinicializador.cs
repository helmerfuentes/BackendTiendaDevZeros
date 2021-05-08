using Domain.Entities.Usuario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Inicializacion
{
    public static class Permisosinicializador
    {
        public static void InicializadorPermiso(MyContext ctx)
        {
            var permisos = new List<Permiso>();
            permisos.Add(new Permiso { Id = 1, Nombre = "Registro Producto", RolId = 1 });
            permisos.Add(new Permiso { Id = 2, Nombre = "Registro Provedor", RolId = 1 });
            ctx.Permisos.AddRange(permisos);
            ctx.SaveChanges();
        }
    }
}
