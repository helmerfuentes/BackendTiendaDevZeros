using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Inicializacion
{
    public static class ProovedorInicializador
    {
        public static void InicializarProvedor(MyContext ctx)
        {
            var provedores = new List<Proovedor>();
            provedores.Add(new Proovedor { Id = 1, Nombre = "Ramiro Gonzales", RazonSocial = "Persona Natural",Nit="1232323434345",Direccion="calle 14c 28-04",Telefono="3145096954" });
            provedores.Add(new Proovedor { Id = 2, Nombre = "Oseas Daniel", RazonSocial = "Persona Natural", Nit = "6534343522334", Direccion = "calle 14c04", Telefono = "3144496954" });
            provedores.Add(new Proovedor { Id = 3, Nombre = "Ferreteria ASA", RazonSocial = "Persona Natural", Nit = "654323400000", Direccion = "calle sdc s8-04", Telefono = "3189989899" });
            ctx.Provedores.AddRange(provedores);
            ctx.SaveChanges();
        }

    }
}
