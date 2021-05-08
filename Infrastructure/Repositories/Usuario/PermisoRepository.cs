using Domain.Entities.Usuario;
using Domain.Repositories;
using Infrastructure.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories.Usuario
{
    public class PermisoRepository : GenericRepository<Permiso>, IPermisoRepository
    {

        public PermisoRepository(IDbContext context) : base(context)
        {

        }
    }
}
