using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using eshop_cartapi.Domain;

namespace eshop_cartapi.UoW
{
    public class UnitOfWorkHelper
    {
        private static IConfiguration _configuration;

        public static void Initialize(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public UnitOfWork GetUnitOfWork()
        {
            var optionBuilder = new DbContextOptionsBuilder<eshop_cartapiContext>();
            optionBuilder.UseSqlServer(_configuration.GetConnectionString("DefaultConnection"));
            var _context = new eshop_cartapiContext(optionBuilder.Options);
            return new UnitOfWork(_context);
        }
    }
}
