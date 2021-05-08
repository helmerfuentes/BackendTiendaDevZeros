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
            personas.Add(new Persona {Id=1,Nombres="Helmer Segundo",Apellidos="Fuentes Alvarado",Documento="123456" });
            personas.Add(new Persona {Id=2,Nombres="nombre1 nombre2",Apellidos="apellido1 apellido2", Documento = "123457" });
            ctx.Personas.AddRange(personas);
            ctx.SaveChanges();

        }
    }
}
