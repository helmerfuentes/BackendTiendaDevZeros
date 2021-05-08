using Domain.Entities;
using Domain.Entities.Usuario;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Utils
{
    public static class Encriptacion
    {
       
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
        public static string BuildToken(User usuario)
        {
            var claims = new[]
            {
                new Claim(ClaimTypes.Name, usuario.Id.ToString()),
                new Claim(ClaimTypes.Role, usuario.Rol.Nombre),
                new Claim(JwtRegisteredClaimNames.UniqueName, usuario.Username),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };
            var encrypt = "pruebaTiendaDevZeros";
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(encrypt));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var expiration = DateTime.UtcNow.AddDays(30);

            var token = new JwtSecurityToken(
               issuer: "yourdomain.com",
               audience: "yourdomain.com",
               claims: claims,
               expires: expiration,
               signingCredentials: credentials
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
           
        }
    }
}
