using ASP_Assignment.Models.Contexts;
using ASP_Assignment.Models.Entities;

namespace ASP_Assignment.Helpers.Repositories
{
    public class AddressRepository : Repository<AddressEntity>
    {
        public AddressRepository(IdentityContext context) : base(context)
        {
        }
    }
}
