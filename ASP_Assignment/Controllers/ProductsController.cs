﻿using ASP_Assignment.Helpers.Services;
using ASP_Assignment.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace ASP_Assignment.Controllers
{
    public class ProductsController : Controller
    {

        #region ProductsService Constructor

        private readonly TagService _tagService;
        private readonly ProductService _productService;
        public ProductsController(ProductService productService, TagService tagService)
        {
            _productService = productService;
            _tagService = tagService;
        }


        #endregion

        public async Task<IActionResult> Index()
        {


            var viewModel = new ProductViewModel
            {
                Products = await _productService.GetAllAsync()
            };


            return View(viewModel);
        }
            


        public async Task<IActionResult> Add()
        {
            ViewBag.Tags = await _tagService.GetTagsAsync();

            return View();
        }

        [HttpPost]
        public async  Task<IActionResult> Add(ProductRegistrationViewModel viewModel, string[] tags)
        {
            if (ModelState.IsValid) 
            {
                var product = await _productService.CreateAsync(viewModel);
                if (product != null)
                {
                    if (viewModel.Image != null)
                        await _productService.UploadImageAsync(product, viewModel.Image);

                        await _productService.AddProductTagsAsync(viewModel, tags);



                    return RedirectToAction("Add");

                }

                ModelState.AddModelError("", "Something Went Wrong.");
            }
            ViewBag.Tags = await _tagService.GetTagsAsync(tags);
            return View(viewModel);
        }
    }
}

