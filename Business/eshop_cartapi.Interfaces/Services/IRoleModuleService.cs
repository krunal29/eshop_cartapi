using eshop_cartapi.Business.ViewModels.Organization;
using eshop_cartapi.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace eshop_cartapi.Interfaces.Services
{
    public interface IRoleModuleService : IBaseService<RoleModule>
    {
        Task<List<RoleModuleModel>> GetAllAsync();

        Task<bool> AddAsync(RoleModuleDetailsModel roleModule);

        Task<bool> UpdateAsync(RoleModuleDetailsModel roleModule);
    }
}