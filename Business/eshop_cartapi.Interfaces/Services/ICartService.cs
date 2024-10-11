using eshop_cartapi.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace eshop_cartapi.Interfaces.Services
{
    public interface ICartService : IBaseService<Cart>
    {
        Task<List<Cart>> GetAllAsync();

        Task<Cart> GetAsync(int id);

        Task<bool> AddAsync(Cart model);

        Task<bool> UpdateAsync(Cart model);

        Task<bool> DeleteAsync(int id);
    }
}