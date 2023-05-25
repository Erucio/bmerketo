using ASP_Assignment.Helpers.Services;
using ASP_Assignment.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

public class HomeController : Controller
{
    private readonly ProductService _productService;

    public HomeController(ProductService productService)
    {
        _productService = productService;
    }

    public async Task<IActionResult> Index()
    {
        var products = new ProductViewModel();

        products.FeaturedProducts = await _productService.GetProductsByTagNameAsync("Featured");
        products.NewProducts = await _productService.GetProductsByTagNameAsync("New");
        products.Products = await _productService.GetAllAsync();
        return View(products);
    }

}