using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ASP_Assignment.Controllers
{

    [Authorize]
    public class AccountController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
