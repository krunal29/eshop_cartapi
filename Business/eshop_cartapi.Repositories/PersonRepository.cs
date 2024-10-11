using eshop_cartapi.Domain;
using eshop_cartapi.Interfaces.Repositories;
using System.Linq;

namespace eshop_cartapi.Repositories
{
    public class PersonRepository : BaseRepository<Person>, IPersonRepository
    {
        public PersonRepository(eshop_cartapiContext context) : base(context)
        {
        }

        public int GetRoleIdBaseonUserid(string id)
        {
            return Context.Person.FirstOrDefault(x => x.AspNetUserId == id).RoleId;
        }
    }
}