using Domain.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Usuario
{
    [Table("Roles")]
    public class Rol: Entity<int>
    {
        public string Nombre { get; set; }
        public EstadoRol Estado { get; set; }
        public ICollection<User> Usuarios { get; set; }
        public ICollection<Permiso> Permisos { get; set; }
    }
}
public enum EstadoRol
{
    Inactivo=0,
    Activo=1,
    Eliminado=2
}
