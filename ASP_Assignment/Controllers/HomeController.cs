using ASP_Assignment.Helpers.Services;
using Microsoft.AspNetCore.Mvc;

public class HomeController : Controller
{
    private readonly ProductService _productService;

    public HomeController(ProductService productService)
    {
        _productService = productService;
    }

    public IActionResult Index()
    {
        var products = _productService.GetProductsByTagId(2);



        return View(products);
    }

}