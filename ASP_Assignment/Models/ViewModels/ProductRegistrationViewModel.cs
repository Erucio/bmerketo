using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ASP_Assignment.Models.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.AspNetCore.Http;
using ASP_Assignment.Models.Contexts;
using Microsoft.EntityFrameworkCore;

namespace ASP_Assignment.Models.ViewModels
{

    public class ProductRegistrationViewModel
    {
        [Required(ErrorMessage = "You must register an Article Number")]
        [Display(Name = "Article Number*")]
        public string ArticleNumber { get; set; } = null!;


        [Required(ErrorMessage ="You must register a Product Name")]
        [Display(Name = "Product Name*")]
        public string Name { get; set; } = null!;



        [Display(Name = "Price (Optional)")]
        [DataType(DataType.Currency)]
        [Column(TypeName = "money")]
        public decimal? Price { get; set; }

        [Display(Name = "Product Description (Optional)")]
        public string? Description { get; set; }

        [DataType(DataType.Upload)]
        public IFormFile? Image { get; set; }

        public static implicit operator ProductEntity(ProductRegistrationViewModel viewModel)
        {
            var entity = new ProductEntity
            {
                ArticleNumber = viewModel.ArticleNumber,
                Name = viewModel.Name,
                Description = viewModel.Description,
                Price = viewModel.Price
            };



            if (viewModel.Image != null)
                entity.ImageUrl = $"{Guid.NewGuid}_{viewModel.Image?.FileName}";
            return entity;
        }

    }
}
