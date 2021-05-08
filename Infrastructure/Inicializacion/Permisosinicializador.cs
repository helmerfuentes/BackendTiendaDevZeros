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
            //PERMISOS DE LIDER
            permisos.Add(new Permiso { Id = 1, Nombre = "Registro Producto", RolId = 1,Codigo="P-00" });
            permisos.Add(new Permiso { Id = 2, Nombre = "Registro Usuario", RolId = 1, Codigo = "U-00" });
            permisos.Add(new Permiso { Id = 3, Nombre = "Registro Compra", RolId = 1, Codigo = "C-00" });
            permisos.Add(new Permiso { Id = 4, Nombre = "Listar Producto", RolId = 1,Codigo="P-01" });
            permisos.Add(new Permiso { Id = 5, Nombre = "Listar Usuario", RolId = 1, Codigo = "U-01" });
            permisos.Add(new Permiso { Id = 6, Nombre = "Listar Compra", RolId = 1, Codigo = "C-01" });

            //PERMISOS INTERESADO
            permisos.Add(new Permiso { Id = 7, Nombre = "Listar Compra", RolId = 2, Codigo = "C-01" });

            //PERMISO VENTAS
            permisos.Add(new Permiso { Id = 8, Nombre = "Registrar Venta", RolId = 3, Codigo = "V-00" });
            permisos.Add(new Permiso { Id = 9, Nombre = "Listar Venta", RolId = 3, Codigo = "V-01" });


            ctx.Permisos.AddRange(permisos);
            ctx.SaveChanges();
        }
    }
}
