using Domain.Entities.Usuario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Inicializacion
{
    public static class Rolinicializador
    {
        public static void InicializadorRol(MyContext ctx)
        {
            var roles = new List<Rol>();
            roles.Add(new Rol { Id = 1, Nombre = "Lider" });
            roles.Add(new Rol { Id = 2, Nombre = "Intersado" });
            roles.Add(new Rol { Id = 3, Nombre = "Ventas" });
            ctx.Roles.AddRange(roles);
            ctx.SaveChanges();
        }
    }
}
