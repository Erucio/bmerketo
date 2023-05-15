using ASP_Assignment.Models.Contexts;
using ASP_Assignment.Models.Entities;

namespace ASP_Assignment.Helpers.Repositories
{
    public class ProductRepository : Repository<ProductEntity>
    {
        public ProductRepository(IdentityContext context) : base(context) 
        {
        }
    }
}
