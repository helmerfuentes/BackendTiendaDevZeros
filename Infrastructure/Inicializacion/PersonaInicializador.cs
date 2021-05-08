﻿using Domain.Entities.Usuario;
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
            personas.Add(new Persona {Id=1,Nombres="Helmer Segundo",Apellidos="Fuentes Alvarado" });
            personas.Add(new Persona {Id=2,Nombres="Helmer Segundo",Apellidos="Fuentes Alvarado" });
            personas.Add(new Persona {Id=3,Nombres="Helmer Segundo",Apellidos="Fuentes Alvarado" });
            personas.Add(new Persona {Id=4,Nombres="Helmer Segundo",Apellidos="Fuentes Alvarado" });
            personas.Add(new Persona {Id=5,Nombres="Helmer Segundo",Apellidos="Fuentes Alvarado" });
            ctx.Personas.AddRange(personas);
            ctx.SaveChanges();

        }
    }
}
