using AutoMapper;
using eshop_cartapi.Domain.Models;
using eshop_cartapi.Interfaces.Services;
using eshop_cartapi.UoW;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eshop_cartapi.Services
{
    public class CartService : ServiceBase, ICartService
    {
        public CartService(IUnitOfWork unitOfWork, IMapper _mapper) : base(unitOfWork, _mapper)
        {
        }

        public async Task<List<Cart>> GetAllAsync()
        {
            var result = mapper.Map<List<Cart>>(await unitOfWork.CartRepository.GetAllAsync());
            return result.ToList();
        }

        public async Task<Cart> GetAsync(int id)
        {
            return mapper.Map<Cart>(await unitOfWork.CartRepository.GetAsync(id));
        }

        public async Task<bool> AddAsync(Cart model)
        {
            await unitOfWork.CartRepository.AddAsync(model);
            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateAsync(Cart model)
        {
            var data = await unitOfWork.CartRepository.GetAsync(model.Id);
            if (data != null)
            {
                data.Id = model.Id;
                //MAP other fields
                await unitOfWork.CartRepository.UpdateAsync(data);
                return await Task.FromResult(true);
            }
            return await Task.FromResult(false);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var data = unitOfWork.CartRepository.GetAsync(id).Result;
            if (data != null)
            {
                await unitOfWork.CartRepository.DeleteAsync(data);
                return await Task.FromResult(true);
            }
            return await Task.FromResult(false);
        }
    }
}