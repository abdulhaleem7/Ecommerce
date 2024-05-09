using Ecommerce.DTOs;
using Ecommerce.Interface.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.Controllers;

public class CategoryController(ICategoryService categoryService): Controller
{
    private readonly ICategoryService _categoryService = categoryService;
    
    // GET
    public async Task<IActionResult> Index()
    {
        var getAllCategories = await _categoryService.GetAllCategories();
        return View(getAllCategories);
    }
    [HttpPost ("Category/Create")]
    public async  Task<IActionResult> Create(CategoryRequestModel categoryModel)
    {
        var createCategory = await _categoryService.CreateCategory(categoryModel);
        return RedirectToAction("Index");
    }
    [HttpGet]
    public async Task<IActionResult> CreateCategory()
    {
        return View();
    }
    [HttpPost("Category/Update/{category}")]
    public async Task<IActionResult> Update(UpdateCategoryRequestModel updateModel, [FromRoute] string category)
    {
        updateModel.OldValue = category;
         await _categoryService.UpdateCategory(updateModel);
        return RedirectToAction("Index");
    }
    [HttpGet("UpdateCategory/{name}")]
    public async Task<IActionResult> UpdateCategory([FromRoute] string name)
    {
        var getCategory = await _categoryService.GetCategory(name);
        return View(getCategory.Data);
    }
        
}
