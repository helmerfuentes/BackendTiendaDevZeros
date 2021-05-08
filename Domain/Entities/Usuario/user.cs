using Domain.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities.Usuario
{
    [Table("Usuarios")]
    public class User : Entity<int>
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public int RolId { get; set; }
        public Rol  Rol { get; set; }
        public int PersonaId { get; set; }
        public Persona Persona { get; set; }
    }
}