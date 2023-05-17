using ASP_Assignment.Helpers.Services;
using ASP_Assignment.Models.Contexts;
using ASP_Assignment.Models.Identity;
using ASP_Assignment.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace ASP_Assignment.Controllers;


public class AdminController : Controller
{
    private readonly ContactFormService _contactFormService;

    public AdminController(ContactFormService contactFormService)
    {
        _contactFormService = contactFormService;
    }

    [Authorize(Roles = "admin")]
    public IActionResult Index()
    {
        return View();
    }


    [Authorize(Roles = "admin")]
    public IActionResult Users()
    {
        var users = new List<UserViewModel>();

        var userManager = HttpContext.RequestServices.GetService(typeof(UserManager<AppUser>)) as UserManager<AppUser>;
        var roleManager = HttpContext.RequestServices.GetService(typeof(RoleManager<IdentityRole>)) as RoleManager<IdentityRole>;

        if (userManager != null && roleManager != null)
        {
            foreach (var user in userManager.Users.ToList())
            {
                var roles = userManager.GetRolesAsync(user).Result;
                var role = roles.FirstOrDefault();

                var userViewModel = new UserViewModel
                {
                    FirstName = user.FirstName ?? string.Empty,
                    LastName = user.LastName ?? string.Empty,
                    Email = user.Email ?? string.Empty,
                    Role = role ?? string.Empty
                };
                users.Add(userViewModel);
            }
        }

        return View(users);
    }

    [Authorize(Roles = "admin")]
    public async Task<IActionResult> Comments()
    {
        var comments = await _contactFormService.GetAllAsync();
        var viewModelList = comments.Select(c => new ContactViewModel
        {
            Name = c.Name,
            Email = c.Email,
            PhoneNumber = c.PhoneNumber,
            CompanyName = c.Company,
            CommentText = c.CommentText,
            RememberMe = c.RememberMe
        }).ToList();

        return View(viewModelList);
    }
}
