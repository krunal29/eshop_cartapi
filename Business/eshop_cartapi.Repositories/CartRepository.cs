using eshop_cartapi.Domain;
using eshop_cartapi.Domain.Models;
using eshop_cartapi.Interfaces.Repositories;

namespace eshop_cartapi.Repositories
{
    public class CartRepository : BaseRepository<Cart>, ICartRepository
    {
        public CartRepository(eshop_cartapiContext context) : base(context)
        {
        }
    }
}