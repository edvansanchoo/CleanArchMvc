﻿using CleanArchMvc.Application.DTOs;
using CleanArchMvc.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchMvc.WebUI.Controllers
{
    public class CategoriesController : Controller
    {
        private readonly ICategoryService _categoryService;

        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var categories = await _categoryService.GetCategoriesAsync();
            return View(categories);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CategoryDTO categoryDTO)
        {
            if (ModelState.IsValid)
            {
                await _categoryService.AddAsync(categoryDTO);
                return RedirectToAction(nameof(Index));
            }
            return View(categoryDTO);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();
            var categoryDTO = await _categoryService.GetByIdAsync(id);
            if (categoryDTO == null) return NotFound();

            return View(categoryDTO);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(CategoryDTO categoryDTO)
        {
            if (ModelState.IsValid)
            {
                await _categoryService.UpdateAsync(categoryDTO);
                return RedirectToAction(nameof(Index));
            }
            return View(categoryDTO);
        }
    }
}
