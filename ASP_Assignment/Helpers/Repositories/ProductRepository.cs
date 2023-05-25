using ASP_Assignment.Models.Contexts;
using ASP_Assignment.Models.Entities;
using ASP_Assignment.Models.Identity;
using Microsoft.EntityFrameworkCore;

namespace ASP_Assignment.Helpers.Repositories
{
    public class ProductRepository : Repository<ProductEntity>
    {
        #region privates and constructors
        private readonly IdentityContext _identityContext;
        public ProductRepository(IdentityContext context, IdentityContext identityContext) : base(context)
        {
            _identityContext = identityContext;
        }
        #endregion


        //Get By Tag ID
        public IEnumerable<ProductEntity> GetProductsByTagId(int tagId)
        {
            return _identityContext.ProductTags
            .Where(pt => pt.TagId == tagId)
            .Select(pt => pt.Product)
            .ToList();
        }

        // Get Async
        public async Task<ProductEntity?> GetAsync(string articleNumber)
        {
            var product = await _identityContext.Products
                .Include(x => x.Tags)
                .ThenInclude(x => x.Tag)
                .FirstOrDefaultAsync(x => x.ArticleNumber == articleNumber);

            return product;
        }
    }
}
