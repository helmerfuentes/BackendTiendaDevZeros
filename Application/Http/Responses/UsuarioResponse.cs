using Domain.Entities.Usuario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Http.Responses
{
    public class UsuarioResponse
    {
        public int Id { get; set; }
        public string Usuario { get; set; }
        public RolResponse Rol { get; set; }
        public PersonaResponse Persona { get; set; }

        public UsuarioResponse(User usuario)
        {
            Id = usuario.Id;
            Usuario = usuario.Username;

        }
        public UsuarioResponse Include(Rol rol)
        {
            if (rol!=null)
            {
                Rol = new RolResponse(rol);
            }
            return this;
        }
        public UsuarioResponse Include(Persona persona)
        {
            if (persona!=null)
            {
                Persona = new PersonaResponse(persona);
            }
            return this;

        }


    }
}
