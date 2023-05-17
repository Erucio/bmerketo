using ASP_Assignment.Models.Identity;

namespace ASP_Assignment.Models.ViewModels;

public class ProductViewModel
{
    public Product? Product { get; set; }
    public IEnumerable<Product> Products { get; set; } = new List<Product>();
}
