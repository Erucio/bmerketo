using ASP_Assignment.Helpers.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

public class ContactController : Controller
{

    #region constructors and privates
    private readonly ContactFormService _contactFormService;


    public ContactController(ContactFormService contactFormService)
    {
        _contactFormService = contactFormService;
    }
    #endregion

    public IActionResult Index()
    {
        return View();
    }



    [HttpPost]
    public async Task<IActionResult> CommentSubmitted(ContactViewModel viewModel)
    {
        if (ModelState.IsValid)
        {
            await _contactFormService.AddAsync(viewModel);

            return View();
        }

        return View(viewModel);
    }



}