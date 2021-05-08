using System;

namespace Application.Http.Responses
{
    public class CrearUsuarioResponse
    {
        public string UserName { get; set; }
        public string Rol { get; set; }
        public DateTime Created { get; set; }
    }
}