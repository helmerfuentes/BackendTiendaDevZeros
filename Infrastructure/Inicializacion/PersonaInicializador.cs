using Domain.Entities.Usuario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Inicializacion
{
    public static class PersonaInicializador
    {
        public static void InicializarPersona(MyContext ctx)
        {
            var personas = new List<Persona>();
            personas.Add(new Persona {Id=1,Nombres="Helmer Segundo",Apellidos="Fuentes Alvarado",Documento="123456",Telefono="3145096907",Direccion="Villa corelca" });
            personas.Add(new Persona {Id=2,Nombres="nombre1 nombre2",Apellidos="Castulo Rodriguez", Documento = "123457", Telefono = "3146543456", Direccion = "calle 14b #45-04" });
            personas.Add(new Persona {Id=3,Nombres="pedro  enrique",Apellidos="Romero Pachecho", Documento = "123457", Telefono = "3145679800", Direccion = "Los fundarores " });
            ctx.Personas.AddRange(personas);
            ctx.SaveChanges();

        }
    }
}
