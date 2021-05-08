using Application.Base;
using Domain.Contract;
using Domain.Entities.Usuario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
   public class PermisoService: Service<Permiso>
    {
        public PermisoService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {

        }
    }
}
