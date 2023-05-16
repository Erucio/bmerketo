using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ASP_Assignment.Models;
using ASP_Assignment.Models.Contexts;
using ASP_Assignment.Models.Identity;
using ASP_Assignment.Helpers.Repositories;

namespace ASP_Assignment.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IdentityContext _context;

        public HomeController(ILogger<HomeController> logger, IdentityContext context)
        {
            _logger = logger;
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
    }
}
