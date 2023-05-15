using ASP_Assignment.Models.Identity;

namespace ASP_Assignment.Models.ViewModels;

public class ProductViewModel
{
    public IEnumerable<Product> Products { get; set; } = new List<Product>();
}
