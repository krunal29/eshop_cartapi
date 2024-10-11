using eshop_cartapi.Domain;
using eshop_cartapi.Interfaces.Repository;

namespace eshop_cartapi.Interfaces.Repositories
{
    public interface IPersonRepository : IBaseRepository<Person>
    {
        int GetRoleIdBaseonUserid(string id);
    }
}