using ASP_Assignment.Helpers.Services;
using ASP_Assignment.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace ASP_Assignment.Controllers
{
    public class LoginController : Controller
    {

        private readonly AuthService _auth;

        public LoginController(AuthService auth)
        {
            _auth = auth;
        }

        public IActionResult Index(string ReturnUrl = null!)
        {
            var viewModel = new UserLoginViewModel();
            if (ReturnUrl != null)
                viewModel.ReturnUrl = ReturnUrl;

            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Index(UserLoginViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                if (await _auth.LoginAsync(viewModel))
                    return LocalRedirect(viewModel.ReturnUrl);

                ModelState.AddModelError("", "Incorrect E-mail or password");

            }

            return View(viewModel);
        }
    }
}

