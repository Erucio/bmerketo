﻿using ASP_Assignment.Helpers.Services;
using ASP_Assignment.Models.Identity;
using ASP_Assignment.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace ASP_Assignment.Controllers;


public class AdminController : Controller
{
    #region privates and constructors

    private readonly ProductService _productService;
    private readonly AuthService _auth;
    private readonly ContactFormService _contactFormService;
    private readonly UserManager<AppUser> _userManager;


    public AdminController(ContactFormService contactFormService, UserManager<AppUser> userManager, AuthService auth, ProductService productService)
    {
        _contactFormService = contactFormService;
        _userManager = userManager;
        _auth = auth;
        _productService = productService;
    }
    #endregion

    //Dashboard View
    [Authorize(Roles = "admin")]
    public async Task<IActionResult> Index()
    {
        var viewModel = new ProductViewModel();
        viewModel.Products = await _productService.GetAllAsync();

        return View(viewModel);
    }

    //User List view with Role Manager
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
                    Id = user.Id,
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

    //Register User Admin-Side (No View)
    [Authorize(Roles = "admin")]
    [HttpPost]
    public async Task<IActionResult> RegisterUser(UserRegisterViewModel viewModel)
    {
        if (ModelState.IsValid)
        {
            if (await _auth.UserAlreadyExistsAsync(x => x.Email == viewModel.Email))
                ModelState.AddModelError("", "An account with that Email already exists");

            if (await _auth.RegisterUserAsync(viewModel))
                return RedirectToAction("Users", "Admin");
        }
        return View(viewModel);
    }


    //Role Manager (No View)
    [Authorize(Roles = "admin")]
    public async Task<IActionResult> UpdateUser(string userId, string newRole)
    {
        var user = await _userManager.FindByIdAsync(userId);
        if (user == null)
        {
            return RedirectToAction("users");
        }
        var currentRoles = await _userManager.GetRolesAsync(user);

        if (!string.IsNullOrEmpty(newRole) && !currentRoles.Contains(newRole))
        {
            await _userManager.RemoveFromRolesAsync(user, currentRoles);
            await _userManager.AddToRoleAsync(user, newRole);
        }

        return RedirectToAction("users");
    }

    //Comments List View
    [Authorize(Roles = "admin")]
    public async Task<IActionResult> Comments()
    {
        var comments = await _contactFormService.GetAllAsync();
        var viewModelList = comments.Select(author => new ContactViewModel
        {
            Id = author.Id,
            Name = author.Name,
            Email = author.Email,
            PhoneNumber = author.PhoneNumber,
            CompanyName = author.Company,
            CommentText = author.CommentText,
            RememberMe = author.RememberMe,
            DateTime = author.DateTime
        }).ToList();

        return View(viewModelList);
    }


    //Delete Comment (No View)
    [Authorize(Roles = "admin")]
    [HttpPost]
    public async Task<IActionResult> DeleteComment(int id)
    {
        var comment = await _contactFormService.GetCommentByIdAsync(id);

        if (comment != null)
        {
            var isDeleted = await _contactFormService.DeleteAsync(comment);

            if (isDeleted)
            {
                return RedirectToAction("comments");
            }
        }

        return RedirectToAction("Error");
    }


    //Register User View (Admin Side)
    [Authorize(Roles = "admin")]
    public IActionResult RegisterUser()
    {
        return View();
    }
}
