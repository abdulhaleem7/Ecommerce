using Ecommerce.DTOs;
using Ecommerce.Interface.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Ecommerce.Controllers;
[Authorize(Roles = "SuperAdmin,Manager")]
public  class UserController(IUserService userService,ICompanyService companyService) : Controller
{
    private readonly IUserService _userService = userService;
    private readonly ICompanyService _companyService = companyService;
    // GET
    public  async Task<IActionResult> Index()
    {
       var rec = await _companyService.GetAllCompany();

       ViewBag.Companies = new SelectList(rec.Data, "Id", "Name");
       var users = await _userService.GetAllUser();
       return View(users);
    }
    [HttpPost("User/Create")]
    public async Task<IActionResult> Create(UserRequestModel requestModel)
    {
        var createUser = await _userService.CreateUser(requestModel);
        return RedirectToAction("Index");

    }
    
    [HttpGet]
    public  async Task<IActionResult> CreateUser()
    {
        return View();
    }
    [HttpPost("User/Update/{userName}")]
    public async Task<IActionResult> Update(UserUpdateModel updateModel, [FromRoute]string userName)
    {
        var updateUser = await _userService.UpdateUser(updateModel, userName);
        if (!updateUser.Status)
        {
            TempData[AppConstant.Error] = updateUser.Mesaage;
            return RedirectToAction("Index");
        }
        TempData[AppConstant.Success] = updateUser.Mesaage;
        return RedirectToAction("Index");
    }
    [HttpGet("User/UpdateUser/{userName}")]
    public async Task<IActionResult> UpdateUser([FromRoute]string userName)
    {
        var getUser = await _userService.GetUser(userName);
        return View(getUser.Data);
    }
}
