using ASP_Assignment.Models.Contexts;
using ASP_Assignment.Models.Entities;

namespace ASP_Assignment.Helpers.Repositories
{
    public class ProductTagRepository : Repository<ProductTagEntity>
    {
        public ProductTagRepository(IdentityContext context) : base(context)
        {
        }
    }
}
