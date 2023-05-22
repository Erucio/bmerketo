using ASP_Assignment.Helpers.Services;
using ASP_Assignment.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace ASP_Assignment.Controllers
{

    public class RegisterTagController : Controller
    {

        private readonly TagService _tagService;

        public RegisterTagController(TagService tagService)
        {
            _tagService = tagService;
        }

        [Authorize(Roles = "admin")]

        public IActionResult Index()
        {
            var viewModel = new TagRegisterViewModel();
            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Index(TagRegisterViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var existingTag = await _tagService.GetTagAsync(viewModel.TagName);
                if (existingTag != null)
                {
                    return Conflict(new { tag = existingTag, error = "This Tag Already Exists" });
                }

                var createdTag = await _tagService.CreateTagAsync(viewModel);
                if (createdTag != null)
                {
                    ModelState.Clear();
                    viewModel.TagCreated = true;
                }
            }

            return View(viewModel);
        }
    }
}
