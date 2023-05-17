using ASP_Assignment.Models.Contexts;
using ASP_Assignment.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace ASP_Assignment.Helpers.Repositories
{
    public class ProductRepository : Repository<ProductEntity>
    {
        private readonly IdentityContext _identityContext;
        public ProductRepository(IdentityContext context, IdentityContext identityContext) : base(context)
        {
            _identityContext = identityContext;
        }
        public IEnumerable<ProductEntity> GetProductsByTagId(int tagId)
        {
            return _identityContext.ProductTags
            .Where(pt => pt.TagId == tagId)
            .Select(pt => pt.Product)
            .ToList();
        }
    }
}
