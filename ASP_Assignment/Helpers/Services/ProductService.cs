using ASP_Assignment.Helpers.Repositories;
using ASP_Assignment.Models.Entities;
using ASP_Assignment.Models.Identity;
using System.Linq;

namespace ASP_Assignment.Helpers.Services
{
    public class ProductService
    {

        #region Constructors and privates
        private readonly TagRepository _tagRepo;
        private readonly ProductRepository _productRepo;
        private readonly ProductTagRepository _productTagRepo;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public ProductService(ProductRepository productRepo, IWebHostEnvironment webHostEnvironment, ProductTagRepository productTagRepo, TagRepository tagRepo)
        {
            _productRepo = productRepo;
            _webHostEnvironment = webHostEnvironment;
            _productTagRepo = productTagRepo;
            _tagRepo = tagRepo;
        }

        #endregion

        public async Task<Product> CreateAsync(ProductEntity entity)
        {
            var _entity = await _productRepo.GetAsync(x => x.ArticleNumber == entity.ArticleNumber);
            if (_entity == null)
            {
                _entity = await _productRepo.AddAsync(entity);
                if (_entity != null)
                    return entity;
            }
            return null!;
        }

        public async Task<bool> UploadImageAsync(Product product, IFormFile image)
        {
            try
            {
                string imagePath = $"{_webHostEnvironment.WebRootPath}/images/products/{product.ImageUrl}";
                await image.CopyToAsync(new FileStream(imagePath, FileMode.Create));
                return true;
            }
            catch { return false; }
        }

        public async Task AddProductTagsAsync(ProductEntity entity, string[] tags)
        {
            foreach (var tag in tags)
            {
                await _productTagRepo.AddAsync(new ProductTagEntity
                {
                    ArticleNumber = entity.ArticleNumber,
                    TagId = int.Parse(tag),

                });
            }
        }


        public async Task<IEnumerable<Product>> GetAllAsync()
        {
            var items = await _productRepo.GetAllAsync();
            var list = new List<Product>();
            foreach (var item in items) 
                list.Add(item);
            return list;

        }

        public async Task<Product> GetByArticleNumberAsync(string articleNumber)
        {
            return await _productRepo.GetAsync(x => x.ArticleNumber == articleNumber);
        }

        public IEnumerable<Product> GetProductsByTagId(int tagId)
        {
            var products = _productRepo.GetProductsByTagId(tagId);
            return products.Select(p => (Product)p).ToList();
        }

        public async Task<bool> DeleteAsync(Product product)
        {
            try
            {
                var productEntity = await _productRepo.GetAsync(x => x.ArticleNumber == product.ArticleNumber);

                if (productEntity != null)
                {
                    bool isDeleted = await _productRepo.DeleteAsync(productEntity);
                    return isDeleted;
                }

                return false;
            }
            catch
            {
                return false;
            }
        }
    }
}
