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
        public string Username { get; set; }
        public string Rol { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string Telefono { get; set; }
        public string Direccion { get; set; }

        public UsuarioResponse(User usuario)
        {
            Id = usuario.Id;
            Username = usuario.Username;
            Rol = usuario.Rol.Nombre;
            Nombres = usuario.Persona.Nombres;
            Apellidos = usuario.Persona.Apellidos;
            Telefono = usuario.Persona.Telefono;
            Direccion = usuario.Persona.Direccion;


        }

    }
}
