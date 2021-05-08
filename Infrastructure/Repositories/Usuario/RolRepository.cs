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
    public class RolRepository : GenericRepository<Rol>, IRolRepository
    {
        public RolRepository(IDbContext context) : base(context)
        {

        }
    }
}
