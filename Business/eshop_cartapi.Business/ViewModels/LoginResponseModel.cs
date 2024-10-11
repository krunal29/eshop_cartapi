using eshop_cartapi.Business.ViewModels.Organization;
using eshop_cartapi.Domain.Models;
using System.Collections.Generic;

namespace eshop_cartapi.Business.ViewModels
{
    public class LoginResponseModel
    {
        public ApplicationUser ApplicationUser { get; set; }

        public string Token { get; set; }

        public List<RoleModuleModel> roleModuleModel { get; set; }
    }
}