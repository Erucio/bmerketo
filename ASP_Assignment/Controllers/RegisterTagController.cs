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

        public async Task<IActionResult> Index()
        {
            var viewModel = new TagRegisterViewModel();
            var tags = await _tagService.GetAllTagsAsync();
            viewModel.Tags = tags.Select(tag => tag.TagName).ToList();
            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Index(TagRegisterViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var tag = await _tagService.GetTagAsync(viewModel.TagName);
                if (tag != null)
                    return Conflict(new { tag, error = "A tag with that name already exists..." });

                tag = await _tagService.CreateTagAsync(viewModel);
                if (tag != null)

                return RedirectToAction("Index");
            }

            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Delete(string tagName)
        {
            var tagToDelete = await _tagService.GetTagAsync(tagName);
            if (tagToDelete != null)
            {
                var result = await _tagService.DeleteTagAsync(tagToDelete);
                if (result)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    return RedirectToAction("Error");
                }
            }
            else
            {
                return RedirectToAction("NotFound");
            }
        }
    }
}
