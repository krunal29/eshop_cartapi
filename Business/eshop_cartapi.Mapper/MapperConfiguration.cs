using AutoMapper;
using eshop_cartapi.Business.ViewModels;
using eshop_cartapi.Business.ViewModels.Organization;
using eshop_cartapi.Domain;
using eshop_cartapi.Domain.Models;

namespace eshop_cartapi.Business.Helpers
{
    public class MapperConfiguration : Profile
    {
        public MapperConfiguration()
        {
            CreateMap<PersonModel, Person>();
            CreateMap<Person, PersonModel>();

            CreateMap<RoleModuleDetailsModel, RoleModule>();
            CreateMap<RoleModule, RoleModuleDetailsModel>();
        }
    }
}