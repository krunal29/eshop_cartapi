using eshop_cartapi.Interfaces.Repositories;
using System;

namespace eshop_cartapi.UoW
{
    public interface IUnitOfWork : IDisposable
    {
        //IPersonRepository PersonRepository { get; }
        //IRoleRepository RoleRepository { get; }
        //IModuleRepository ModuleRepository { get; }
        //IAccessModuleRepository AccessModuleRepository { get; }
        //IRoleModuleRepository RoleModuleRepository { get; }
        ICartRepository CartRepository { get; }


    }
}