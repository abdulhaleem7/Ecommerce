using Ecommerce.DTOs;
using Ecommerce.Interface.Services;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.Controllers;

public class CompanyController(ICompanyService companyService) : Controller
{
    private readonly ICompanyService _companyService = companyService;
    // GET
    public async Task<IActionResult> Index()
    {
        var getCompany = await _companyService.GetAllCompany();
        return View(getCompany);
    }
    [HttpPost("Company/Create")]
    public async Task<IActionResult> Create(CompanyRequestModel requestModel)
    {
        var createCompany = await _companyService.CreateCompany(requestModel);
        return RedirectToAction("Index");
    }
    [HttpGet]
    public async Task<IActionResult> CreateCompany()
    {
        return View();
    }
    [HttpPost("Company/Update")]
    public async Task<IActionResult> Update(CompanyUpdateModel updateModel)
    {
        var updateCompany = await _companyService.UpdateCompany(updateModel);
        if (!updateCompany.Status)
        {
            TempData[AppConstant.Error] = updateCompany.Mesaage;
            return RedirectToAction("index");
        }

        TempData[AppConstant.Success] = updateCompany.Mesaage;
        return RedirectToAction("Index");
    }
    [HttpGet("UpdateCompany/{id:guid}")]
    public async Task<IActionResult> UpdateCompany([FromRoute] Guid id)
    {
        var updateCompany = await _companyService.GetCompanyById(id);
        return View(updateCompany.Data);
    }
}