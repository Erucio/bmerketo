using Microsoft.AspNetCore.Mvc;

namespace ASP_Assignment.Controllers;

public class ContactsController : Controller
{
    public IActionResult Index()
    {
        ViewData["Title"] = "Contact Us";

        return View();
    }
}
