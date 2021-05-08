using Domain.Entities.Usuario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Http.Responses
{
   public class PersonaResponse
    {
        public int Id { get; set; }
        public string Documento { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string Telefono { get; set; }
        public string Direccion { get; set; }

        public PersonaResponse(Persona persona)
        {
            Id = persona.Id;
            Documento = persona.Documento;
            Nombres = persona.Nombres;
            Apellidos = persona.Apellidos;
            Telefono = persona.Telefono;
            Direccion = persona.Direccion;
        }
        public PersonaResponse()
        {

        }
    }
}
