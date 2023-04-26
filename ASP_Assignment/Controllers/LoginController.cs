using ASP_Assignment.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace ASP_Assignment.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(UserLoginViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                return View();
            }

            ModelState.AddModelError("", "Incorrect E-mail or password");
            return View();
        }
    }
}
