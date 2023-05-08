using ASP_Assignment.Helpers.Services;
using ASP_Assignment.Models.ViewModels;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;

namespace ASP_Assignment.Controllers
{
    public class RegisterController : Controller
    {

        private readonly AuthService _auth;

        public RegisterController(AuthService auth)
        {
            _auth = auth;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(UserRegisterViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                if (await _auth.UserAlreadyExistsAsync(x => x.Email == viewModel.Email))
                    ModelState.AddModelError("", "An account with that Email already exists");


                if (await _auth.RegisterUserAsync(viewModel))
                    return RedirectToAction("index","login");
            }
            return View(viewModel);
        }
    }
}
