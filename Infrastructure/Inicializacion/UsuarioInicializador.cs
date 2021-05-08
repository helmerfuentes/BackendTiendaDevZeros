using Domain.Entities.Usuario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Inicializacion
{
    public static class UsuarioInicializador
    {
        public static void  InicializarUsuario(MyContext ctx)
        {
            var usuarios = new List<User>();
            usuarios.Add(new User { Id = 1, Username = "helmerfa", PersonaId = 1, RolId = 1, Password = GetSha256("123456") });
            usuarios.Add(new User { Id = 2, Username="helmerfa2",PersonaId=2,RolId=2, Password = GetSha256("123456") });
            usuarios.Add(new User { Id = 3, Username="helmerfa3",PersonaId=3,RolId=1, Password = GetSha256("123456") });
            ctx.Users.AddRange(usuarios);
            ctx.SaveChanges();
        }

        public static string GetSha256(string str)
        {
            var sha256 = SHA256.Create();
            var encoding = new ASCIIEncoding();
            byte[] stream = null;
            var sb = new StringBuilder();
            stream = sha256.ComputeHash(encoding.GetBytes(str));
            foreach (var t in stream)
                sb.AppendFormat("{0:x2}", t);
            return sb.ToString();
        }
    }
}
