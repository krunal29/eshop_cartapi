using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using eshop_cartapi.Domain.Models;

namespace eshop_cartapi.Domain
{
    public partial class eshop_cartapiContext : IdentityDbContext<ApplicationUser>
    {
        public eshop_cartapiContext(DbContextOptions<eshop_cartapiContext> options) : base(options)
        {
        }

        public DbSet<Person> Person { get; set; }

        public DbSet<Cart>Cart{ get; set; }



        public virtual DbSet<AccessModule> AccessModules { get; set; }
        public virtual DbSet<Module> Modules { get; set; }
        public virtual DbSet<Role> AccessRoles { get; set; }
        public virtual DbSet<RoleModule> RoleModules { get; set; }

        public virtual DbSet<Role> Roles { get; set; }
    }
}