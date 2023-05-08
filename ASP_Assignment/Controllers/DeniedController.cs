using Microsoft.AspNetCore.Mvc;

namespace ASP_Assignment.Controllers
{
    public class DeniedController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
