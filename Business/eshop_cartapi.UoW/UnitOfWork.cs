using eshop_cartapi.Domain;
using eshop_cartapi.Interfaces.Repositories;
using eshop_cartapi.Repositories;
using System;

namespace eshop_cartapi.UoW
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly eshop_cartapiContext Context;

        public UnitOfWork(eshop_cartapiContext context)
        {
            this.Context = context;
            //PersonRepository = new PersonRepository(Context);
            //RoleRepository = new RoleRepository(Context);
            //ModuleRepository = new ModuleRepository(Context);
            //RoleModuleRepository = new RoleModuleRepository(Context);
            CartRepository = new CartRepository(Context); 


        }

        //public IPersonRepository PersonRepository { get; }
        //public IRoleRepository RoleRepository { get; }
        //public IModuleRepository ModuleRepository { get; }
        //public IAccessModuleRepository AccessModuleRepository { get; }
        //public IRoleModuleRepository RoleModuleRepository { get; }

        public ICartRepository CartRepository { get; }



        private bool disposed;

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed && disposing)
            {
                Context.Dispose();
            }
            disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}