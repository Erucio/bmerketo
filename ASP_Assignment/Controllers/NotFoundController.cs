using Microsoft.AspNetCore.Mvc;

namespace ASP_Assignment.Controllers
{
    public class NotFoundController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
