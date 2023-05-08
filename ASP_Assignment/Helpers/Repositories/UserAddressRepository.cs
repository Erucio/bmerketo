using ASP_Assignment.Models.Contexts;
using ASP_Assignment.Models.Entities;

namespace ASP_Assignment.Helpers.Repositories
{
    public class UserAddressRepository : Repository<UserAddressEntity>
    {
        public UserAddressRepository(IdentityContext context) : base(context)
        {
        }
    }
}
