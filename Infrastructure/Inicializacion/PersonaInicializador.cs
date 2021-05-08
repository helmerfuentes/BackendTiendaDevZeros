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
            personas.Add(new Persona {Id=2,Nombres="Helmer Segundo",Apellidos="Fuentes Alvarado", Documento = "123457" });
            personas.Add(new Persona {Id=3,Nombres="Helmer Segundo",Apellidos="Fuentes Alvarado", Documento = "1234568" });
            personas.Add(new Persona {Id=4,Nombres="Helmer Segundo",Apellidos="Fuentes Alvarado", Documento = "1234569" });
            personas.Add(new Persona {Id=5,Nombres="Helmer Segundo",Apellidos="Fuentes Alvarado", Documento = "1234569" });
            ctx.Personas.AddRange(personas);
            ctx.SaveChanges();

        }
    }
}
