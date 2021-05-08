using Domain.Entities;
using Domain.Entities.Usuario;
using Domain.Repositories;
using Infrastructure.Base;

namespace Infrastructure.Repositories
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(IDbContext context) : base(context)
        {
        }
    }
}