using Domain.Entities.Usuario;

namespace Application.Http.Responses
{
    public class LoginUserResponse
    {
        public string Usuario { get; set; }
        public string Token { get; set; }
        public RolResponse Rol { get; set; }

        public LoginUserResponse(User usuario)
        {
            Usuario = usuario.Username;

        }
        public LoginUserResponse Include(Rol rol)
        {
            if (rol!=null)
            {
                Rol = new RolResponse(rol).Include(rol.Permisos);
                
            }
            return this;
        }
        public LoginUserResponse Include(string token)
        {
            Token = token;
            return this;
        }


    }
}