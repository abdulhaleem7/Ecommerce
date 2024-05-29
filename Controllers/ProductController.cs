using Ecommerce.DTOs;
using Ecommerce.FileStorages;
using Ecommerce.Interface.Services;
using Ecommerce.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Ecommerce.Controllers;

public class ProductController(IProductService productService,
                                IFileStorage fileStorage,
                                ICompanyService companyService,
                                ICategoryService categoryService) : Controller
{
    private readonly IProductService _productService = productService;
    private readonly ICompanyService _companyService = companyService;
    private readonly ICategoryService _categoryService = categoryService;
    private readonly IFileStorage _fileStorage = fileStorage;
    // GET
    public async Task<IActionResult> Index()
    {
        var getAllProduct = await _productService.GetAllProduct();
        return View(getAllProduct);
    }
    [HttpPost("Product/CreateProduct")]
    public async Task<IActionResult> CreateProduct(IFormFile file ,ProductRequestModel requestModel)
    {
        string filename = await _fileStorage.UploadToRootServerAsync(file, "Product");
        requestModel.Image = filename;
        var createProduct = await _productService.CreateProduct(requestModel);
        
        return RedirectToAction("Index");
    }

    [HttpGet]
    public async Task<IActionResult> Create()
    {
        var rec = await _companyService.GetAllCompany();
        ViewBag.Companies = new SelectList(rec.Data, "Id", "Name");
        var category = await _categoryService.GetAllCategories();
        ViewBag.Categories = new SelectList(rec.Data, "Id", "Name");
        
        return View();
    }
    
    [HttpPost("Product/UpdateProduct")]
    public async Task<IActionResult> UpdateProduct(UpdateRequestModel requestModel)
    {
        var updateProduct = await _productService.UpdateProduct(requestModel);
        if (!updateProduct.Status)
        {
            TempData[AppConstant.Error] = updateProduct.Mesaage;
            return RedirectToAction("Index");
        }

        TempData[AppConstant.Success] = updateProduct.Mesaage;
        return RedirectToAction("Index");
    }

    [HttpGet("Update/{id:guid}")]
    public async Task<IActionResult> Update([FromRoute] Guid id)
    {
        var updateProduct = _productService.GetProduct(id);
        return View(updateProduct);
    }
}