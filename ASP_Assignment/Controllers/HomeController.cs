using Microsoft.AspNetCore.Mvc;
using ASP_Assignment.Models.Contexts;

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

        public IActionResult Index()
        {

            return View();
        }


    }
}
