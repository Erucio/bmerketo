using ASP_Assignment.Helpers.Services;
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
        var tagName = "Featured";
        var products = await _productService.GetProductsByTagNameAsync(tagName);

        return View(products);
    }

}