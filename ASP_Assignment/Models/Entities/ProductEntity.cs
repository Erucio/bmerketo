using ASP_Assignment.Models.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ASP_Assignment.Models.Entities
{
    public class ProductEntity
    {
        [Key]
        public string ArticleNumber { get; set; } = null!;
        public string Name { get; set; } = null!;

        [Column(TypeName = "money")]
        public decimal? Price { get; set; }
        public string? Description { get; set; }
        public string? ImageUrl { get; set; }



        public ICollection<ProductTagEntity> ProductTags { get; set; } = new HashSet<ProductTagEntity>();





        public static implicit operator Product(ProductEntity entity)
        {
            if (entity != null)
            {
                return new Product
                {
                    ArticleNumber = entity.ArticleNumber,
                    Name = entity.Name,
                    Description = entity.Description,
                    Price = entity.Price,
                    ImageUrl = entity.ImageUrl

                };
            }
            return null!;
        }
    }
}
