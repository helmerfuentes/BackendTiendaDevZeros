using Domain.Base;
using Domain.Entities.Usuario;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Usuario
{
    [Table("Permisos")]
    public class Permiso: Entity<int>
    {
        public string Nombre { get; set; }
        public string Codigo { get; set; }
        public EstadoPermiso Estado { get; set; }
        public int RolId { get; set; }
        public Rol Rol{ get; set; }
    }
}
public enum EstadoPermiso
{
    Inactivo = 0,
    Activo = 1,
    Eliminado = 2
}
