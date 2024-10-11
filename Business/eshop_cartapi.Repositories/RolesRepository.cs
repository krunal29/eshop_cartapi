using eshop_cartapi.Domain;
using eshop_cartapi.Domain.Models;
using eshop_cartapi.Interfaces.Repositories;

namespace eshop_cartapi.Repositories
{
    public class RoleRepository : BaseRepository<Role>, IRoleRepository
    {
        public RoleRepository(eshop_cartapiContext context) : base(context)
        {
        }
    }
}