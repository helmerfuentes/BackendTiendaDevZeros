using Domain.Entities.Usuario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Http.Responses
{
    public class RolResponse
    {
        public int Id { get; set; }
        public string Nombre { get; set; }

        public List<PermisoResponse> Permisos{ get; set; }

        public RolResponse(Rol rol)
        {
            Id = rol.Id;
            Nombre = rol.Nombre;
        }
        public RolResponse Include(ICollection<Permiso> permiso)
        {
            if (permiso!=null)
            {
                Permisos = permiso.ToList().ConvertAll(x => new PermisoResponse(x));
            }
            return this;
        }

    }
}
