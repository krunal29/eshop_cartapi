using eshop_cartapi.Domain;
using eshop_cartapi.Domain.Models;
using eshop_cartapi.Interfaces.Repositories;

namespace eshop_cartapi.Repositories
{
    public class ModuleRepository : BaseRepository<Module>, IModuleRepository
    {
        public ModuleRepository(eshop_cartapiContext context) : base(context)
        {
        }
    }
}